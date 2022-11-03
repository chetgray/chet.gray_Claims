CREATE PROCEDURE [dbo].[spA_Claim_Insert]
      @patientLastName                    NVARCHAR(50)
    , @patientFirstName                   NVARCHAR(50)
    , @patientMiddleName                  NVARCHAR(50)
    , @patientStreet                      NVARCHAR(50)
    , @patientCity                        NVARCHAR(50)
    , @patientState                       NVARCHAR(50)
    , @patientZip                         CHAR(5)
    , @patientPhoneNumber                 NVARCHAR(50)
    , @patientEmailAddress                NVARCHAR(50)
    , @carrierName                        NVARCHAR(50)
    , @carrierCustomerServicePhoneNumber  NVARCHAR(50)
    , @hospitalName                       NVARCHAR(50)
    , @hospitalStreet                     NVARCHAR(50)
    , @hospitalCity                       NVARCHAR(50)
    , @hospitalState                      NVARCHAR(50)
    , @hospitalZip                        CHAR(5)
    , @procedureCode                      VARCHAR(50)
    , @procedureName                      NVARCHAR(50)
    , @claimOutstandingAmount             MONEY
    , @claimInsuranceResponsibilityAmount MONEY

AS

DECLARE @claimId INT;

---------------------------------------------------
-- Check if Patient exists, insert if it doesn't --
---------------------------------------------------
DECLARE @patientId INT;
SELECT
    @patientId = [Patient].[Id]
FROM
               [Patient]
    INNER JOIN [Address]      ON [Patient].[AddressId]      = [Address].[Id]
    INNER JOIN [City]         ON [Address].[CityId]         = [City].[Id]
    INNER JOIN [State]        ON [City].[StateId]           = [State].[Id]
    INNER JOIN [Zip]          ON [Address].[ZipId]          = [Zip].[Id]
    INNER JOIN [PhoneNumber]  ON [Patient].[PhoneNumberId]  = [PhoneNumber].[Id]
    INNER JOIN [EmailAddress] ON [Patient].[EmailAddressId] = [EmailAddress].[Id]
WHERE
        [Patient].[LastName]          = @patientLastName
    AND [Patient].[FirstName]         = @patientFirstName
    AND [Patient].[MiddleName]        = @patientMiddleName
    AND [Address].[Street]            = @patientStreet
    AND [City].[Name]                 = @patientCity
    AND [State].[Name]                = @patientState
    AND [Zip].[Code]                  = @patientZip
    AND [PhoneNumber].[PhoneNumber]   = @patientPhoneNumber
    AND [EmailAddress].[EmailAddress] = @patientEmailAddress
;
IF (@patientId IS NULL)
BEGIN
    EXEC [spA_Patient_Insert]
          @patientLastName
        , @patientFirstName
        , @patientMiddleName
        , @patientStreet
        , @patientCity
        , @patientState
        , @patientZip
        , @patientPhoneNumber
        , @patientEmailAddress
    ;
    SELECT @patientId = @@IDENTITY;
END

------------------------------------------------------------------
-- Check if Carrier with same Name exists, insert if it doesn't --
------------------------------------------------------------------
DECLARE @carrierId INT;
SELECT
    @carrierId = [Carrier].[Id]
FROM
    [Carrier]
WHERE
    [Carrier].[Name] = @carrierName
;
IF (@carrierId IS NULL)
BEGIN
    EXEC [spA_Carrier_Insert]
          @carrierName
        , @carrierCustomerServicePhoneNumber
    ;
    SELECT @carrierId = @@IDENTITY;
END

-------------------------------------------------------------------
-- Check if Hospital with same Name exists, insert if it doesn't --
-------------------------------------------------------------------
DECLARE @hospitalId INT;
SELECT
    @hospitalId = [Hospital].[Id]
FROM
    [Hospital]
WHERE
    [Hospital].[Name] = @hospitalName
;
IF (@hospitalId IS NULL)
BEGIN
    EXEC [spA_Hospital_Insert]
          @hospitalName
        , @hospitalStreet
        , @hospitalCity
        , @hospitalState
        , @hospitalZip
    ;
    SELECT @hospitalId = @@IDENTITY;
END

-----------------------------------------------------
-- Check if Procedure exists, insert if it doesn't --
-----------------------------------------------------
DECLARE @procedureId INT;
SELECT
    @procedureId = [Procedure].[Id]
FROM
    [Procedure]
WHERE
       [Procedure].[Code] = @procedureCode
    OR [Procedure].[Name] = @procedureName
;
IF (@procedureId IS NULL)
BEGIN
    EXEC [spA_Procedure_Insert]
         @procedureCode
        , @procedureName
    ;
    SELECT @procedureId = @@IDENTITY;
END

------------------
-- Insert Claim --
------------------
INSERT
INTO [Claim] (
      [PatientId]
    , [CarrierId]
    , [HospitalId]
    , [ProcedureId]
    , [OutstandingAmount]
    , [InsuranceResponsibilityAmount]
)
VALUES (
      @patientId
    , @carrierId
    , @hospitalId
    , @procedureId
    , @claimOutstandingAmount
    , @claimInsuranceResponsibilityAmount
)
;
SELECT @claimId = SCOPE_IDENTITY();

-----------------------------------------------------------------
-- Select Claim with Patient, Carrier, Hospital, and Procedure --
-----------------------------------------------------------------
SELECT
      [Claim].[Id]                            AS [ClaimId]
    , [Patient].[Id]                          AS [PatientId]
    , [Patient].[LastName]                    AS [PatientLastName]
    , [Patient].[FirstName]                   AS [PatientFirstName]
    , [Patient].[MiddleName]                  AS [PatientMiddleName]
    , [P_Address].[Street]                    AS [PatientStreet]
    , [P_City].[Name]                         AS [PatientCity]
    , [P_State].[Name]                        AS [PatientState]
    , [P_Zip].[Code]                          AS [PatientZip]
    , [P_PhoneNumber].[PhoneNumber]           AS [PatientPhoneNumber]
    , [P_EmailAddress].[EmailAddress]         AS [PatientEmailAddress]
    , [Carrier].[Id]                          AS [CarrierId]
    , [Carrier].[Name]                        AS [CarrierName]
    , [C_PhoneNumber].[PhoneNumber]           AS [CarrierCustomerServicePhoneNumber]
    , [Hospital].[Id]                         AS [HospitalId]
    , [Hospital].[Name]                       AS [HospitalName]
    , [H_Address].[Street]                    AS [HospitalStreet]
    , [H_City].[Name]                         AS [HospitalCity]
    , [H_State].[Name]                        AS [HospitalState]
    , [H_Zip].[Code]                          AS [HospitalZip]
    , [Procedure].[Id]                        AS [ProcedureId]
    , [Procedure].[Code]                      AS [ProcedureCode]
    , [Procedure].[Name]                      AS [ProcedureName]
    , [Claim].[OutstandingAmount]             AS [ClaimOutstandingAmount]
    , [Claim].[InsuranceResponsibilityAmount] AS [ClaimInsuranceResponsibilityAmount]
FROM
               [Claim]
    INNER JOIN [Patient]                          ON [Claim].[PatientId]                      = [Patient].[Id]
    INNER JOIN [Address]      AS [P_Address]      ON [Patient].[AddressId]                    = [P_Address].[Id]
    INNER JOIN [City]         AS [P_City]         ON [P_Address].[CityId]                     = [P_City].[Id]
    INNER JOIN [State]        AS [P_State]        ON [P_City].[StateId]                       = [P_State].[Id]
    INNER JOIN [Zip]          AS [P_Zip]          ON [P_Address].[ZipId]                      = [P_Zip].[Id]
    INNER JOIN [PhoneNumber]  AS [P_PhoneNumber]  ON [Patient].[PhoneNumberId]                = [P_PhoneNumber].[Id]
    INNER JOIN [EmailAddress] AS [P_EmailAddress] ON [Patient].[EmailAddressId]               = [P_EmailAddress].[Id]
    INNER JOIN [Carrier]                          ON [Claim].[CarrierId]                      = [Carrier].[Id]
    INNER JOIN [PhoneNumber]  AS [C_PhoneNumber]  ON [Carrier].[CustomerServicePhoneNumberId] = [C_PhoneNumber].[Id]
    INNER JOIN [Hospital]                         ON [Claim].[HospitalId]                     = [Hospital].[Id]
    INNER JOIN [Address]      AS [H_Address]      ON [Hospital].[AddressId]                   = [H_Address].[Id]
    INNER JOIN [City]         AS [H_City]         ON [H_Address].[CityId]                     = [H_City].[Id]
    INNER JOIN [State]        AS [H_State]        ON [H_City].[StateId]                       = [H_State].[Id]
    INNER JOIN [Zip]          AS [H_Zip]          ON [H_Address].[ZipId]                      = [H_Zip].[Id]
    INNER JOIN [Procedure]                        ON [Claim].[ProcedureId]                    = [Procedure].[Id]
WHERE
    [Claim].[Id] = @claimId
;
