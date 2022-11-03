CREATE PROCEDURE [dbo].[spA_Procedure_Insert]
      @procedureCode VARCHAR(50)
    , @procedureName NVARCHAR(50)
AS

DECLARE @procedureId INT;

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
SELECT @procedureId = @@IDENTITY;

SELECT
      [Procedure].[Id]   AS [ProcedureId]
    , [Procedure].[Code] AS [ProcedureCode]
    , [Procedure].[Name] AS [ProcedureName]
FROM
    [Procedure]
WHERE
    [Procedure].[Id] = @procedureId
;
