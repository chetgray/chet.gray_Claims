CREATE PROCEDURE [dbo].[spA_Address_Insert]
    @street NVARCHAR(50)
    , @city NVARCHAR(50)
    , @state NVARCHAR(50)
    , @zip CHAR(5)
AS

DECLARE @addressID INT;

-------------------------------------------------
-- Check if State exists, insert if it doesn't --
-------------------------------------------------
DECLARE @stateID INT;
SELECT
    @stateID = [StateID]
FROM
    [State]
WHERE
    [Name] = @state
;
IF (@stateID IS NULL)
BEGIN
    INSERT
    INTO [State] (
        [Name]
    )
    VALUES (
        @state
    )
    ;
    SELECT @stateID = SCOPE_IDENTITY();
END

------------------------------------------------
-- Check if City exists, insert if it doesn't --
------------------------------------------------
DECLARE @cityID INT;
SELECT
    @cityID = [CityID]
FROM
    [City]
WHERE
    [Name] = @city
    AND [StateID] = @stateID
;
IF (@cityID IS NULL)
BEGIN
    INSERT
    INTO [City] (
        [Name]
        , [StateID]
    )
    VALUES (
        @city
        , @stateID
    )
    ;
    SELECT @cityID = SCOPE_IDENTITY();
END

-----------------------------------------------
-- Check if Zip exists, insert if it doesn't --
-----------------------------------------------
DECLARE @zipID INT;
SELECT
    @zipID = [ZipID]
FROM
    [Zip]
WHERE
    [Code] = @zip
;
IF (@zipID IS NULL)
BEGIN
    INSERT
    INTO [Zip] (
        [Code]
    )
    VALUES (
        @zip
    )
    ;
    SELECT @zipID = SCOPE_IDENTITY();
END

--------------------
-- Insert Address --
--------------------
INSERT
INTO [Address] (
    [Street]
    , [CityID]
    , [ZipID]
)
VALUES (
    @street
    , @cityID
    , @zipID
)
;
SELECT @addressID = SCOPE_IDENTITY();

--------------------
-- Select Address --
--------------------
SELECT
    [AddressID]
    , [Address].[Street] AS [Street]
    , [City].[Name]      AS [City]
    , [State].[Name]     AS [State]
    , [Zip].[Code]       AS [Zip]
FROM
    [Address]
    INNER JOIN [City]  ON [Address].[CityID] = [City].[CityID]
    INNER JOIN [State] ON [City].[StateID]   = [State].[StateID]
    INNER JOIN [Zip]   ON [Address].[ZipID]  = [Zip].[ZipID]
WHERE
    [AddressID] = @addressID
;
