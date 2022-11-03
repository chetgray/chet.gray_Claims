CREATE TABLE [dbo].[Procedure]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Procedure_Id] PRIMARY KEY
    , [Code] VARCHAR(50) NOT NULL
        CONSTRAINT [AK_Procedure_Code] UNIQUE ([Code])
    , [Name] NVARCHAR(50) NOT NULL
        CONSTRAINT [AK_Procedure_Name] UNIQUE ([Name])
)
