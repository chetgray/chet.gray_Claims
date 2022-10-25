CREATE TABLE [dbo].[Patient]
(
    [PatientID] INT IDENTITY NOT NULL CONSTRAINT [PK_Patient_PatientID] PRIMARY KEY
    , [LastName] NVARCHAR(50) NOT NULL
    , [FirstName] NVARCHAR(50) NOT NULL
    , [MiddleName] NVARCHAR(50) NULL
    , [AddressID] INT NOT NULL
        CONSTRAINT [FK_Patient_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Address]([AddressID])
    , [PhoneNumberID] INT NOT NULL
        CONSTRAINT [FK_Patient_PhoneNumberID] FOREIGN KEY ([PhoneNumberID]) REFERENCES [PhoneNumber]([PhoneNumberID])
    , [EmailAddressID] INT NOT NULL
        CONSTRAINT [FK_Patient_EmailAddressID] FOREIGN KEY ([EmailAddressID]) REFERENCES [EmailAddress]([EmailAddressID])
)
