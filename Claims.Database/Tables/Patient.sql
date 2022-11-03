CREATE TABLE [dbo].[Patient]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Patient_Id] PRIMARY KEY
    , [LastName] NVARCHAR(50) NOT NULL
    , [FirstName] NVARCHAR(50) NOT NULL
    , [MiddleName] NVARCHAR(50) NULL
    , [AddressId] INT NOT NULL
        CONSTRAINT [FK_Patient_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
    , [PhoneNumberId] INT NOT NULL
        CONSTRAINT [FK_Patient_PhoneNumberId] FOREIGN KEY ([PhoneNumberId]) REFERENCES [PhoneNumber]([Id])
    , [EmailAddressId] INT NOT NULL
        CONSTRAINT [FK_Patient_EmailAddressId] FOREIGN KEY ([EmailAddressId]) REFERENCES [EmailAddress]([Id])
    , CONSTRAINT [AK_Patient] UNIQUE ([LastName], [FirstName], [MiddleName], [AddressId], [PhoneNumberId], [EmailAddressId])
)
