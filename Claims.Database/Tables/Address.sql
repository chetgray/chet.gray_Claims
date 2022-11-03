CREATE TABLE [dbo].[Address]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Address_Id] PRIMARY KEY
    , [Street] NVARCHAR(50) NOT NULL
    , [CityId] INT NULL
        CONSTRAINT [FK_Address_CityId] FOREIGN KEY ([CityId]) REFERENCES [City]([Id])
    , [ZipId] INT NULL
        CONSTRAINT [FK_Address_ZipId] FOREIGN KEY ([ZipId]) REFERENCES [Zip]([Id])
    , CONSTRAINT [CK_Address_CityIdZipIdNotBothNull] CHECK (([CityId] IS NOT NULL) OR ([ZipId] IS NOT NULL))
)
