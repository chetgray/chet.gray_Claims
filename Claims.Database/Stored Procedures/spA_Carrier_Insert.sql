CREATE PROCEDURE [dbo].[spA_Carrier_Insert]
    @carrierName NVARCHAR(50)
    , @carrierCustomerServicePhoneNumber NVARCHAR(50)
AS

DECLARE @carrierID INT;

------------------------
-- Insert PhoneNumber --
------------------------
DECLARE @phoneNumberID INT;
INSERT
INTO [PhoneNumber] (
    [PhoneNumber]
)
VALUES (
    @carrierCustomerServicePhoneNumber
)
;
SELECT @phoneNumberID = SCOPE_IDENTITY();

--------------------
-- Insert Carrier --
--------------------
INSERT
INTO [Carrier] (
    [Name]
    , [CustomerServicePhoneNumberID]
)
VALUES (
    @carrierName
    , @phoneNumberID
)
;
SELECT @carrierID = SCOPE_IDENTITY();

-------------------------------------
-- Select Carrier with PhoneNumber --
-------------------------------------
SELECT
    [CarrierID]
    , [Carrier].[Name]              AS [CarrierName]
    , [C_PhoneNumber].[PhoneNumber] AS [CarrierCustomerServicePhoneNumber]
FROM
    [Carrier]
    INNER JOIN [PhoneNumber] AS [C_PhoneNumber] ON [Carrier].[CustomerServicePhoneNumberID] = [C_PhoneNumber].[PhoneNumberID]
WHERE
    [CarrierID] = @carrierID
;
