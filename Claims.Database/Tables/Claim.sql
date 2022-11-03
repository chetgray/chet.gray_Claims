CREATE TABLE [dbo].[Claim]
(
    [ClaimID] INT IDENTITY NOT NULL CONSTRAINT [PK_Claim_ClaimID] PRIMARY KEY
    , [PatientID] INT NOT NULL
        CONSTRAINT [FK_Claim_PatientID] FOREIGN KEY ([PatientID]) REFERENCES [Patient]([PatientID])
    , [CarrierID] INT NOT NULL
        CONSTRAINT [FK_Claim_CarrierID] FOREIGN KEY ([CarrierID]) REFERENCES [Carrier]([CarrierID])
    , [HospitalID] INT NOT NULL
        CONSTRAINT [FK_Claim_HospitalID] FOREIGN KEY ([HospitalID]) REFERENCES [Hospital]([HospitalID])
    , [ProcedureID] INT NOT NULL
        CONSTRAINT [FK_Claim_ProcedureID] FOREIGN KEY ([ProcedureID]) REFERENCES [Procedure]([ProcedureID])
    , [OutstandingAmount] MONEY NOT NULL
    , [InsuranceResponsibilityAmount] MONEY NOT NULL
)
