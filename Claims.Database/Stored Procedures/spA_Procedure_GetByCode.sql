CREATE PROCEDURE [dbo].[spA_Procedure_GetByCode]
    @code VARCHAR(50)
AS

SELECT TOP 1
    [ProcedureID]
    , [Code] AS [ProcedureCode]
    , [Name] AS [ProcedureName]
FROM
    [Procedure]
WHERE
    [Code] = @code
;
