CREATE PROCEDURE [dbo].[spA_Patient_Insert]
      @patientLastName     NVARCHAR(50)
    , @patientFirstName    NVARCHAR(50)
    , @patientMiddleName   NVARCHAR(50)
    , @patientStreet       NVARCHAR(50)
    , @patientCity         NVARCHAR(50)
    , @patientState        NVARCHAR(50)
    , @patientZip          CHAR(5)
    , @patientPhoneNumber  NVARCHAR(50)
    , @patientEmailAddress NVARCHAR(50)
AS

DECLARE @patientId INT;

--------------------
-- Insert Address --
--------------------
DECLARE @addressId INT;
EXEC [spA_Address_Insert]
      @patientStreet
    , @patientCity
    , @patientState
    , @patientZip
;
SELECT @addressId = @@IDENTITY;

------------------------
-- Insert PhoneNumber --
------------------------
DECLARE @phoneNumberId INT;
INSERT
INTO [PhoneNumber] (
    [PhoneNumber]
)
VALUES (
    @patientPhoneNumber
)
;
SELECT @phoneNumberId = SCOPE_IDENTITY();

-------------------------
-- Insert EmailAddress --
-------------------------
DECLARE @emailAddressId INT;
INSERT
INTO [EmailAddress] (
    [EmailAddress]
)
VALUES (
    @patientEmailAddress
)
;
SELECT @emailAddressId = SCOPE_IDENTITY();

--------------------
-- Insert Patient --
--------------------
INSERT
INTO [Patient] (
      [LastName]
    , [FirstName]
    , [MiddleName]
    , [AddressId]
    , [PhoneNumberId]
    , [EmailAddressId]
)
VALUES (
      @patientLastName
    , @patientFirstName
    , @patientMiddleName
    , @addressId
    , @phoneNumberId
    , @emailAddressId
)
;
SELECT @patientId = SCOPE_IDENTITY();

----------------------------------------------------------------
-- Select Patient with Address, PhoneNumber, and EmailAddress --
----------------------------------------------------------------
SELECT
      [Patient].[Id]                  AS [PatientId]
    , [Patient].[LastName]            AS [PatientLastName]
    , [Patient].[FirstName]           AS [PatientFirstName]
    , [Patient].[MiddleName]          AS [PatientMiddleName]
    , [P_Address].[Street]            AS [PatientStreet]
    , [P_City].[Name]                 AS [PatientCity]
    , [P_State].[Name]                AS [PatientState]
    , [P_Zip].[Code]                  AS [PatientZip]
    , [P_PhoneNumber].[PhoneNumber]   AS [PatientPhoneNumber]
    , [P_EmailAddress].[EmailAddress] AS [PatientEmailAddress]
FROM
               [Patient]
    INNER JOIN [Address]      AS [P_Address]      ON [Patient].[AddressId]      = [P_Address].[Id]
    INNER JOIN [City]         AS [P_City]         ON [P_Address].[CityId]       = [P_City].[Id]
    INNER JOIN [State]        AS [P_State]        ON [P_City].[StateId]         = [P_State].[Id]
    INNER JOIN [Zip]          AS [P_Zip]          ON [P_Address].[ZipId]        = [P_Zip].[Id]
    INNER JOIN [PhoneNumber]  AS [P_PhoneNumber]  ON [Patient].[PhoneNumberId]  = [P_PhoneNumber].[Id]
    INNER JOIN [EmailAddress] AS [P_EmailAddress] ON [Patient].[EmailAddressId] = [P_EmailAddress].[Id]
WHERE
    [Patient].[Id] = @patientId
;
