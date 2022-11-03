CREATE TABLE [dbo].[PhoneNumber]
(
    [PhoneNumberID] INT IDENTITY NOT NULL CONSTRAINT [PK_PhoneNumber_PhoneNumberID] PRIMARY KEY
    , [PhoneNumber] VARCHAR(50) NOT NULL
)
