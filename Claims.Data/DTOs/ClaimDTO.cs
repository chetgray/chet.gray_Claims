﻿namespace Claims.Data.DTOs
{
    public class ClaimDTO : BaseDTO
    {
        public PatientDTO Patient { get; set; }
        public CarrierDTO Carrier { get; set; }
        public HospitalDTO Hospital { get; set; }
        public ProcedureDTO Procedure { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal InsuranceResponsibilityAmount { get; set; }
    }
}
