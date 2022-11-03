CREATE PROCEDURE [dbo].[spA_Procedure_GetByCode]
    @procedureCode VARCHAR(50)
AS

SELECT TOP 1
      [Procedure].[Id]   AS [ProcedureId]
    , [Procedure].[Code] AS [ProcedureCode]
    , [Procedure].[Name] AS [ProcedureName]
FROM
    [Procedure]
WHERE
    [Procedure].[Code] = @procedureCode
;
