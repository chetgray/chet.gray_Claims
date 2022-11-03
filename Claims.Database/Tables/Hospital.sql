CREATE TABLE [dbo].[Hospital]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Hospital_Id] PRIMARY KEY
    , [Name] NVARCHAR(50) NOT NULL
        CONSTRAINT [AK_Hospital_Name] UNIQUE ([Name])
    , [AddressId] INT NOT NULL
        CONSTRAINT [FK_Hospital_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
