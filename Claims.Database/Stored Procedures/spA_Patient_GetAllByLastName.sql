CREATE PROCEDURE [dbo].[spA_Patient_GetAllByLastName]
    @patientLastName VARCHAR(50)
AS

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
    [Patient].[LastName] = @patientLastName
;
