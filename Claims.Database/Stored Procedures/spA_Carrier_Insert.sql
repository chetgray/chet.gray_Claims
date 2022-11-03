CREATE PROCEDURE [dbo].[spA_Carrier_Insert]
      @carrierName                       NVARCHAR(50)
    , @carrierCustomerServicePhoneNumber NVARCHAR(50)
AS

DECLARE @carrierId INT;

------------------------
-- Insert PhoneNumber --
------------------------
DECLARE @customerServicePhoneNumberId INT;
INSERT
INTO [PhoneNumber] (
    [PhoneNumber]
)
VALUES (
    @carrierCustomerServicePhoneNumber
)
;
SELECT @customerServicePhoneNumberId = SCOPE_IDENTITY();

--------------------
-- Insert Carrier --
--------------------
INSERT
INTO [Carrier] (
      [Name]
    , [CustomerServicePhoneNumberId]
)
VALUES (
      @carrierName
    , @customerServicePhoneNumberId
)
;
SELECT @carrierId = SCOPE_IDENTITY();

-------------------------------------
-- Select Carrier with PhoneNumber --
-------------------------------------
SELECT
      [Carrier].[Id]                AS [CarrierId]
    , [Carrier].[Name]              AS [CarrierName]
    , [C_PhoneNumber].[PhoneNumber] AS [CarrierCustomerServicePhoneNumber]
FROM
               [Carrier]
    INNER JOIN [PhoneNumber] AS [C_PhoneNumber] ON [Carrier].[CustomerServicePhoneNumberId] = [C_PhoneNumber].[Id]
WHERE
    [Carrier].[Id] = @carrierId
;
