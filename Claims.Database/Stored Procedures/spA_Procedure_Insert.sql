CREATE PROCEDURE [dbo].[spA_Procedure_Insert]
    @procedureCode VARCHAR(50)
    , @procedureName NVARCHAR(50)
AS

DECLARE @procedureID INT;

INSERT
INTO [Procedure] (
    [Code]
    , [Name]
)
VALUES (
    @procedureCode
    , @procedureName
)
;
SELECT @procedureID = @@IDENTITY;

SELECT
    [Procedure].[ProcedureID]
    , [Procedure].[Code] AS [ProcedureCode]
    , [Procedure].[Name] AS [ProcedureName]
FROM
    [Procedure]
WHERE
    [ProcedureID] = @procedureID
;
