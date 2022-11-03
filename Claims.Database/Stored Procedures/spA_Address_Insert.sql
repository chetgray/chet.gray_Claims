CREATE PROCEDURE [dbo].[spA_Address_Insert]
      @street NVARCHAR(50)
    , @city   NVARCHAR(50)
    , @state  NVARCHAR(50)
    , @zip    CHAR(5)
AS

DECLARE @addressId INT;

-------------------------------------------------
-- Check if State exists, insert if it doesn't --
-------------------------------------------------
DECLARE @stateId INT;
SELECT
    @stateId = [State].[Id]
FROM
    [State]
WHERE
    [State].[Name] = @state
;
IF (@stateId IS NULL)
BEGIN
    INSERT
    INTO [State] (
        [Name]
    )
    VALUES (
        @state
    )
    ;
    SELECT @stateId = SCOPE_IDENTITY();
END

------------------------------------------------
-- Check if City exists, insert if it doesn't --
------------------------------------------------
DECLARE @cityId INT;
SELECT
    @cityId = [City].[Id]
FROM
    [City]
WHERE
        [City].[Name]    = @city
    AND [City].[StateId] = @stateId
;
IF (@cityId IS NULL)
BEGIN
    INSERT
    INTO [City] (
          [Name]
        , [StateId]
    )
    VALUES (
          @city
        , @stateId
    )
    ;
    SELECT @cityId = SCOPE_IDENTITY();
END

-----------------------------------------------
-- Check if Zip exists, insert if it doesn't --
-----------------------------------------------
DECLARE @zipId INT;
SELECT
    @zipId = [Zip].[Id]
FROM
    [Zip]
WHERE
    [Zip].[Code] = @zip
;
IF (@zipId IS NULL)
BEGIN
    INSERT
    INTO [Zip] (
        [Code]
    )
    VALUES (
        @zip
    )
    ;
    SELECT @zipId = SCOPE_IDENTITY();
END

--------------------
-- Insert Address --
--------------------
INSERT
INTO [Address] (
    [Street]
    , [CityId]
    , [ZipId]
)
VALUES (
    @street
    , @cityId
    , @zipId
)
;
SELECT @addressId = SCOPE_IDENTITY();

--------------------
-- Select Address --
--------------------
SELECT
      [Address].[Id]     AS [AddressId]
    , [Address].[Street] AS [Street]
    , [City].[Name]      AS [City]
    , [State].[Name]     AS [State]
    , [Zip].[Code]       AS [Zip]
FROM
               [Address]
    INNER JOIN [City]  ON [Address].[CityId] = [City].[Id]
    INNER JOIN [State] ON [City].[StateId]   = [State].[Id]
    INNER JOIN [Zip]   ON [Address].[ZipId]  = [Zip].[Id]
WHERE
    [Address].[Id] = @addressId
;
