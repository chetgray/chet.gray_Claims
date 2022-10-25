CREATE TABLE [dbo].[Carrier]
(
    [CarrierID] INT IDENTITY NOT NULL CONSTRAINT [PK_Carrier_CarrierID] PRIMARY KEY
    , [Name] NVARCHAR(50) NOT NULL
    , [CustomerServicePhoneNumberID] INT NOT NULL
        CONSTRAINT [FK_Carrier_CustomerServicePhoneNumberID] FOREIGN KEY ([CustomerServicePhoneNumberID]) REFERENCES [PhoneNumber]([PhoneNumberID])
)
