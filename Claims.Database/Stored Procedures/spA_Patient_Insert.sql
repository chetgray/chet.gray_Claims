CREATE PROCEDURE [dbo].[spA_Patient_Insert]
    @patientLastName NVARCHAR(50)
    , @patientFirstName NVARCHAR(50)
    , @patientMiddleName NVARCHAR(50)
    , @patientStreet NVARCHAR(50)
    , @patientCity NVARCHAR(50)
    , @patientState NVARCHAR(50)
    , @patientZip CHAR(5)
    , @patientPhoneNumber NVARCHAR(50)
    , @patientEmailAddress NVARCHAR(50)
AS

DECLARE @patientID INT;

--------------------
-- Insert Address --
--------------------
DECLARE @addressID INT;
EXEC [spA_Address_Insert]
    @patientStreet
    , @patientCity
    , @patientState
    , @patientZip
;
SELECT @addressID = @@IDENTITY;

------------------------
-- Insert PhoneNumber --
------------------------
DECLARE @phoneNumberID INT;
INSERT
INTO [PhoneNumber] (
    [PhoneNumber]
)
VALUES (
    @patientPhoneNumber
)
;
SELECT @phoneNumberID = SCOPE_IDENTITY();

-------------------------
-- Insert EmailAddress --
-------------------------
DECLARE @emailAddressID INT;
INSERT
INTO [EmailAddress] (
    [EmailAddress]
)
VALUES (
    @patientEmailAddress
)
;
SELECT @emailAddressID = SCOPE_IDENTITY();

--------------------
-- Insert Patient --
--------------------
INSERT
INTO [Patient] (
    [LastName]
    , [FirstName]
    , [MiddleName]
    , [AddressID]
    , [PhoneNumberID]
    , [EmailAddressID]
)
VALUES (
    @patientLastName
    , @patientFirstName
    , @patientMiddleName
    , @addressID
    , @phoneNumberID
    , @emailAddressID
)
;
SELECT @patientID = SCOPE_IDENTITY();

----------------------------------------------------------------
-- Select Patient with Address, PhoneNumber, and EmailAddress --
----------------------------------------------------------------
SELECT
    [Patient].[PatientID]
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
    INNER JOIN [Address]      AS [P_Address]      ON [Patient].[AddressID]      = [P_Address].[AddressID]
    INNER JOIN [City]         AS [P_City]         ON [P_Address].[CityID]       = [P_City].[CityID]
    INNER JOIN [State]        AS [P_State]        ON [P_City].[StateID]         = [P_State].[StateID]
    INNER JOIN [Zip]          AS [P_Zip]          ON [P_Address].[ZipID]        = [P_Zip].[ZipID]
    INNER JOIN [PhoneNumber]  AS [P_PhoneNumber]  ON [Patient].[PhoneNumberID]  = [P_PhoneNumber].[PhoneNumberID]
    INNER JOIN [EmailAddress] AS [P_EmailAddress] ON [Patient].[EmailAddressID] = [P_EmailAddress].[EmailAddressID]
WHERE
    [Patient].[PatientID] = @patientID
;
