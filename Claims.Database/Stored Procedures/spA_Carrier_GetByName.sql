CREATE PROCEDURE [dbo].[spA_Carrier_GetByName]
    @carrierName NVARCHAR(50)
AS

SELECT TOP 1
      [Carrier].[Id]                AS [CarrierId]
    , [Carrier].[Name]              AS [CarrierName]
    , [C_PhoneNumber].[PhoneNumber] AS [CarrierCustomerServicePhoneNumber]
FROM
               [Carrier]
    INNER JOIN [PhoneNumber] AS [C_PhoneNumber] ON [Carrier].[CustomerServicePhoneNumberId] = [C_PhoneNumber].[Id]
WHERE
    [Carrier].[Name] = @carrierName
;
