CREATE PROCEDURE [dbo].[spA_Procedure_Insert]
    @code varchar(50)
    , @name nvarchar(50)
AS

INSERT
INTO [dbo].[Procedure] (
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
    [dbo].[Procedure]
WHERE
    [ProcedureID] = SCOPE_IDENTITY()
;

GO
