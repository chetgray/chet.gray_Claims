﻿CREATE TABLE [dbo].[State]
(
    [StateID] INT IDENTITY NOT NULL CONSTRAINT [PK_State_StateID] PRIMARY KEY
    , [Name] NVARCHAR(50) NOT NULL
        CONSTRAINT [AK_State_Name] UNIQUE ([Name])
)
