CREATE TABLE [dbo].[Carrier]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Carrier_Id] PRIMARY KEY
    , [Name] NVARCHAR(50) NOT NULL
        CONSTRAINT [AK_Carrier_Name] UNIQUE ([Name])
    , [CustomerServicePhoneNumberId] INT NOT NULL
        CONSTRAINT [FK_Carrier_CustomerServicePhoneNumberId] FOREIGN KEY ([CustomerServicePhoneNumberId]) REFERENCES [PhoneNumber]([Id])
)
