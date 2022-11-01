CREATE TABLE [dbo].[Hospital]
(
    [HospitalID] INT IDENTITY NOT NULL CONSTRAINT [PK_Hospital_HospitalID] PRIMARY KEY
    , [Name] NVARCHAR(50) NOT NULL
        CONSTRAINT [AK_Hospital_Name] UNIQUE ([Name])
    , [AddressID] INT NOT NULL
        CONSTRAINT [FK_Hospital_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Address]([AddressID])
)
