CREATE PROCEDURE [dbo].[spA_Hospital_GetByName]
    @hospitalName NVARCHAR(50)
AS

SELECT TOP 1
    [Hospital].[HospitalID]
    , [Hospital].[Name]    AS [HospitalName]
    , [H_Address].[Street] AS [HospitalStreet]
    , [H_City].[Name]      AS [HospitalCity]
    , [H_State].[Name]     AS [HospitalState]
    , [H_Zip].[Code]       AS [HospitalZip]
FROM
    [Hospital]
    INNER JOIN [Address] AS [H_Address] ON [Hospital].[AddressID] = [H_Address].[AddressID]
    INNER JOIN [City]    AS [H_City]    ON [H_Address].[CityID]   = [H_City].[CityID]
    INNER JOIN [State]   AS [H_State]   ON [H_City].[StateID]     = [H_State].[StateID]
    INNER JOIN [Zip]     AS [H_Zip]     ON [H_Address].[ZipID]    = [H_Zip].[ZipID]
WHERE
    [Hospital].[Name] = @hospitalName
;
