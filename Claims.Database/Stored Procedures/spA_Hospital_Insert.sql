CREATE PROCEDURE [dbo].[spA_Hospital_Insert]
    @hospitalName NVARCHAR(50)
    , @hospitalStreet NVARCHAR(50)
    , @hospitalCity NVARCHAR(50)
    , @hospitalState NVARCHAR(50)
    , @hospitalZip CHAR(5)
AS

DECLARE @hospitalID INT;

--------------------
-- Insert Address --
--------------------
DECLARE @addressID INT;
EXEC [spA_Address_Insert]
    @hospitalStreet
    , @hospitalCity
    , @hospitalState
    , @hospitalZip
;
SELECT @addressID = @@IDENTITY;

---------------------
-- Insert Hospital --
---------------------
INSERT
INTO [Hospital] (
    [Name]
    , [AddressID]
)
VALUES (
    @hospitalName
    , @addressID
)
;
SELECT @hospitalID = SCOPE_IDENTITY();

----------------------------------
-- Select Hospital with Address --
----------------------------------
SELECT
    [HospitalID]
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
    [HospitalID] = @hospitalID
;