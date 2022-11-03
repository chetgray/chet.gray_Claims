CREATE TABLE [dbo].[EmailAddress]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_EmailAddress_Id] PRIMARY KEY
    , [EmailAddress] VARCHAR(50) NOT NULL
)
