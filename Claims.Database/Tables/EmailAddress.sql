CREATE TABLE [dbo].[EmailAddress]
(
    [EmailAddressID] INT IDENTITY NOT NULL CONSTRAINT [PK_EmailAddress_EmailAddressID] PRIMARY KEY
    , [EmailAddress] VARCHAR(50) NOT NULL
)
