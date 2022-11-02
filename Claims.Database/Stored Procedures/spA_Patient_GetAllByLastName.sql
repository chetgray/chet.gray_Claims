CREATE PROCEDURE [dbo].[spA_Patient_GetAllByLastName]
    @patientLastName VARCHAR(50)
AS

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
    [Patient].[LastName] = @patientLastName
;
