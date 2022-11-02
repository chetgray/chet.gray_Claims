CREATE PROCEDURE [dbo].[spA_Carrier_GetByName]
    @carrierName NVARCHAR(50)
AS

SELECT TOP 1
    [Carrier].[CarrierID]
    , [Carrier].[Name]              AS [CarrierName]
    , [C_PhoneNumber].[PhoneNumber] AS [CarrierCustomerServicePhoneNumber]
FROM
    [Carrier]
    INNER JOIN [PhoneNumber] AS [C_PhoneNumber] ON [Carrier].[CustomerServicePhoneNumberID] = [C_PhoneNumber].[PhoneNumberID]
WHERE
    [Carrier].[Name] = @carrierName
;
