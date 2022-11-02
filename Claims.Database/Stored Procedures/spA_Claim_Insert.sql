CREATE PROCEDURE [dbo].[spA_Claim_Insert]
    @patientLastName NVARCHAR(50)
    , @patientFirstName NVARCHAR(50)
    , @patientMiddleName NVARCHAR(50)
    , @patientStreet NVARCHAR(50)
    , @patientCity NVARCHAR(50)
    , @patientState NVARCHAR(50)
    , @patientZip CHAR(5)
    , @patientPhoneNumber NVARCHAR(50)
    , @patientEmailAddress NVARCHAR(50)
    , @carrierName NVARCHAR(50)
    , @carrierCustomerServicePhoneNumber NVARCHAR(50)
    , @hospitalName NVARCHAR(50)
    , @hospitalStreet NVARCHAR(50)
    , @hospitalCity NVARCHAR(50)
    , @hospitalState NVARCHAR(50)
    , @hospitalZip CHAR(5)
    , @procedureCode VARCHAR(50)
    , @procedureName NVARCHAR(50)
    , @claimOutstandingAmount MONEY
    , @claimInsuranceResponsibilityAmount MONEY

AS

DECLARE @claimID INT;

---------------------------------------------------
-- Check if Patient exists, insert if it doesn't --
---------------------------------------------------
DECLARE @patientID INT;
SELECT @patientID = [PatientID]
FROM
    [Patient]
    INNER JOIN [Address] ON [Patient].[AddressID] = [Address].[AddressID]
    INNER JOIN [City] ON [Address].[CityID] = [City].[CityID]
    INNER JOIN [State] ON [City].[StateID] = [State].[StateID]
    INNER JOIN [Zip] ON [Address].[ZipID] = [Zip].[ZipID]
    INNER JOIN [PhoneNumber] ON [Patient].[PhoneNumberID] = [PhoneNumber].[PhoneNumberID]
    INNER JOIN [EmailAddress] ON [Patient].[EmailAddressID] = [EmailAddress].[EmailAddressID]
WHERE [LastName] = @patientLastName
    AND [FirstName] = @patientFirstName
    AND [MiddleName] = @patientMiddleName
    AND [Street] = @patientStreet
    AND [City].[Name] = @patientCity
    AND [State].[Name] = @patientState
    AND [Zip].[Code] = @patientZip
    AND [PhoneNumber] = @patientPhoneNumber
    AND [EmailAddress] = @patientEmailAddress
;
IF (@patientID IS NULL)
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
    SELECT @patientID = @@IDENTITY;
END

------------------------------------------------------------------
-- Check if Carrier with same Name exists, insert if it doesn't --
------------------------------------------------------------------
DECLARE @carrierID INT;
SELECT @carrierID = [CarrierID]
FROM
    [Carrier]
WHERE
    [Name] = @carrierName
;
IF (@carrierID IS NULL)
BEGIN
    EXEC [spA_Carrier_Insert]
        @carrierName
        , @carrierCustomerServicePhoneNumber
    ;
    SELECT @carrierID = @@IDENTITY;
END

-------------------------------------------------------------------
-- Check if Hospital with same Name exists, insert if it doesn't --
-------------------------------------------------------------------
DECLARE @hospitalID INT;
SELECT @hospitalID = [HospitalID]
FROM
    [Hospital]
WHERE
    [Name] = @hospitalName
;
IF (@hospitalID IS NULL)
BEGIN
    EXEC [spA_Hospital_Insert]
        @hospitalName
        , @hospitalStreet
        , @hospitalCity
        , @hospitalState
        , @hospitalZip
    ;
    SELECT @hospitalID = @@IDENTITY;
END

-----------------------------------------------------
-- Check if Procedure exists, insert if it doesn't --
-----------------------------------------------------
DECLARE @procedureID INT;
SELECT @procedureID = [ProcedureID]
FROM
    [Procedure]
WHERE
    [Code] = @procedureCode
    OR [Name] = @procedureName
;
IF (@procedureID IS NULL)
BEGIN
    EXEC [spA_Procedure_Insert]
        @procedureCode
        , @procedureName
    ;
    SELECT @procedureID = @@IDENTITY;
END

------------------
-- Insert Claim --
------------------
INSERT
INTO [Claim] (
    [PatientID]
    , [CarrierID]
    , [HospitalID]
    , [ProcedureID]
    , [OutstandingAmount]
    , [InsuranceResponsibilityAmount]
)
VALUES (
    @patientID
    , @carrierID
    , @hospitalID
    , @procedureID
    , @claimOutstandingAmount
    , @claimInsuranceResponsibilityAmount
)
;
SELECT @claimID = SCOPE_IDENTITY();

-----------------------------------------------------------------
-- Select Claim with Patient, Carrier, Hospital, and Procedure --
-----------------------------------------------------------------
SELECT
    [Claim].[ClaimID]
    , [Patient].[LastName]                    AS [PatientLastName]
    , [Patient].[FirstName]                   AS [PatientFirstName]
    , [Patient].[MiddleName]                  AS [PatientMiddleName]
    , [P_Address].[Street]                    AS [PatientStreet]
    , [P_City].[Name]                         AS [PatientCity]
    , [P_State].[Name]                        AS [PatientState]
    , [P_Zip].[Code]                          AS [PatientZip]
    , [P_PhoneNumber].[PhoneNumber]           AS [PatientPhoneNumber]
    , [P_EmailAddress].[EmailAddress]         AS [PatientEmailAddress]
    , [Carrier].[Name]                        AS [CarrierName]
    , [C_PhoneNumber].[PhoneNumber]           AS [CarrierCustomerServicePhoneNumber]
    , [Hospital].[Name]                       AS [HospitalName]
    , [H_Address].[Street]                    AS [HospitalStreet]
    , [H_City].[Name]                         AS [HospitalCity]
    , [H_State].[Name]                        AS [HospitalState]
    , [H_Zip].[Code]                          AS [HospitalZip]
    , [Procedure].[Code]                      AS [ProcedureCode]
    , [Procedure].[Name]                      AS [ProcedureName]
    , [Claim].[OutstandingAmount]             AS [ClaimOutstandingAmount]
    , [Claim].[InsuranceResponsibilityAmount] AS [ClaimInsuranceResponsibilityAmount]
FROM
    [Claim]
    INNER JOIN [Patient]                          ON [Claim].[PatientID]                      = [Patient].[PatientID]
    INNER JOIN [Address]      AS [P_Address]      ON [Patient].[AddressID]                    = [P_Address].[AddressID]
    INNER JOIN [City]         AS [P_City]         ON [P_Address].[CityID]                     = [P_City].[CityID]
    INNER JOIN [State]        AS [P_State]        ON [P_City].[StateID]                       = [P_State].[StateID]
    INNER JOIN [Zip]          AS [P_Zip]          ON [P_Address].[ZipID]                      = [P_Zip].[ZipID]
    INNER JOIN [PhoneNumber]  AS [P_PhoneNumber]  ON [Patient].[PhoneNumberID]                = [P_PhoneNumber].[PhoneNumberID]
    INNER JOIN [EmailAddress] AS [P_EmailAddress] ON [Patient].[EmailAddressID]               = [P_EmailAddress].[EmailAddressID]
    INNER JOIN [Carrier]                          ON [Claim].[CarrierID]                      = [Carrier].[CarrierID]
    INNER JOIN [PhoneNumber]  AS [C_PhoneNumber]  ON [Carrier].[CustomerServicePhoneNumberID] = [C_PhoneNumber].[PhoneNumberID]
    INNER JOIN [Hospital]                         ON [Claim].[HospitalID]                     = [Hospital].[HospitalID]
    INNER JOIN [Address]      AS [H_Address]      ON [Hospital].[AddressID]                   = [H_Address].[AddressID]
    INNER JOIN [City]         AS [H_City]         ON [H_Address].[CityID]                     = [H_City].[CityID]
    INNER JOIN [State]        AS [H_State]        ON [H_City].[StateID]                       = [H_State].[StateID]
    INNER JOIN [Zip]          AS [H_Zip]          ON [H_Address].[ZipID]                      = [H_Zip].[ZipID]
    INNER JOIN [Procedure]                        ON [Claim].[ProcedureID]                    = [Procedure].[ProcedureID]
WHERE
    [Claim].[ClaimID] = @claimID
;
