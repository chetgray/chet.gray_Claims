CREATE TABLE [dbo].[Claim]
(
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Claim_Id] PRIMARY KEY
    , [PatientId] INT NOT NULL
        CONSTRAINT [FK_Claim_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patient]([Id])
    , [CarrierId] INT NOT NULL
        CONSTRAINT [FK_Claim_CarrierId] FOREIGN KEY ([CarrierId]) REFERENCES [Carrier]([Id])
    , [HospitalId] INT NOT NULL
        CONSTRAINT [FK_Claim_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospital]([Id])
    , [ProcedureId] INT NOT NULL
        CONSTRAINT [FK_Claim_ProcedureId] FOREIGN KEY ([ProcedureId]) REFERENCES [Procedure]([Id])
    , [OutstandingAmount] MONEY NOT NULL
    , [InsuranceResponsibilityAmount] MONEY NOT NULL
)
