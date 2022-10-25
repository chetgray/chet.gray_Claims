CREATE TABLE [dbo].[Procedure]
(
    [ProcedureID] INT IDENTITY NOT NULL CONSTRAINT [PK_Procedure_ProcedureID] PRIMARY KEY
    , [Code] CHAR(10) NOT NULL
        CONSTRAINT [AK_Procedure_Code] UNIQUE ([Code])
    , [Name] NVARCHAR(50) NOT NULL
)
