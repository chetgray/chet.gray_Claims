CREATE PROCEDURE [dbo].[spA_Hospital_Insert]
      @hospitalName   NVARCHAR(50)
    , @hospitalStreet NVARCHAR(50)
    , @hospitalCity   NVARCHAR(50)
    , @hospitalState  NVARCHAR(50)
    , @hospitalZip    CHAR(5)
AS

DECLARE @hospitalId INT;

--------------------
-- Insert Address --
--------------------
DECLARE @addressId INT;
EXEC [spA_Address_Insert]
      @hospitalStreet
    , @hospitalCity
    , @hospitalState
    , @hospitalZip
;
SELECT @addressId = @@IDENTITY;

---------------------
-- Insert Hospital --
---------------------
INSERT
INTO [Hospital] (
      [Name]
    , [AddressId]
)
VALUES (
      @hospitalName
    , @addressId
)
;
SELECT @hospitalId = SCOPE_IDENTITY();

----------------------------------
-- Select Hospital with Address --
----------------------------------
SELECT
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
    [Hospital].[Id] = @hospitalId
;