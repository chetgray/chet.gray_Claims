CREATE PROCEDURE [dbo].[spA_Procedure_Insert]
    @code varchar(50)
    , @name nvarchar(50)
AS

INSERT
INTO [Procedure] (
    [Code]
    , [Name]
)
VALUES (
    @code
    , @name
)
;

SELECT
    [ProcedureID]
    , [Code]
    , [Name]
FROM
    [Procedure]
WHERE
    [ProcedureID] = SCOPE_IDENTITY()
;
