CREATE PROCEDURE [dbo].[spA_Hospital_GetByName]
    @hospitalName NVARCHAR(50)
AS

SELECT TOP 1
      [Hospital].[Id]      AS [HospitalId]
    , [Hospital].[Name]    AS [HospitalName]
    , [H_Address].[Street] AS [HospitalStreet]
    , [H_City].[Name]      AS [HospitalCity]
    , [H_State].[Name]     AS [HospitalState]
    , [H_Zip].[Code]       AS [HospitalZip]
FROM
               [Hospital]
    INNER JOIN [Address] AS [H_Address] ON [Hospital].[AddressId] = [H_Address].[Id]
    INNER JOIN [City]    AS [H_City]    ON [H_Address].[CityId]   = [H_City].[Id]
    INNER JOIN [State]   AS [H_State]   ON [H_City].[StateId]     = [H_State].[Id]
    INNER JOIN [Zip]     AS [H_Zip]     ON [H_Address].[ZipId]    = [H_Zip].[Id]
WHERE
    [Hospital].[Name] = @hospitalName
;
