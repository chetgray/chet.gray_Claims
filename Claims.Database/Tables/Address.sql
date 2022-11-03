CREATE TABLE [dbo].[Address]
(
    [AddressID] INT IDENTITY NOT NULL CONSTRAINT [PK_Address_AddressID] PRIMARY KEY
    , [Street] NVARCHAR(50) NOT NULL
    , [CityID] INT NULL
        CONSTRAINT [FK_Address_CityID] FOREIGN KEY ([CityID]) REFERENCES [City]([CityID])
    , [ZipID] INT NULL
        CONSTRAINT [FK_Address_ZipID] FOREIGN KEY ([ZipID]) REFERENCES [Zip]([ZipID])
    , CONSTRAINT [CK_Address_CityIDZipIDNotBothNull] CHECK (([CityID] IS NOT NULL) OR ([ZipID] IS NOT NULL))
)
