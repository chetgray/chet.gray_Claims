﻿CREATE TABLE [dbo].[Zip]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Zip_Id] PRIMARY KEY
    , [Code] CHAR(5) NOT NULL
        CONSTRAINT [AK_Zip_Code] UNIQUE ([Code])
)
