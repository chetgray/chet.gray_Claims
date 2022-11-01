CREATE PROCEDURE [dbo].[spA_Procedure_GetByCode]
    @code varchar(50)
AS

SELECT TOP 1
    [ProcedureID]
    , [Code]
    , [Name]
FROM
    [Procedure]
WHERE
    [Code] = @code
;
