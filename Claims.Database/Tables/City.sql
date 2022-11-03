﻿CREATE TABLE [dbo].[City]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_City_Id] PRIMARY KEY
    , [Name] NVARCHAR(50) NOT NULL
    , [StateId] INT NOT NULL
        CONSTRAINT [FK_City_StateId] FOREIGN KEY ([StateId]) REFERENCES [State]([Id])
)
