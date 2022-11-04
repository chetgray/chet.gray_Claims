namespace Claims.Data.DTOs
{
    public class ClaimDTO
    {
        public int? Id { get; set; }
        public PatientDTO Patient { get; set; } = new PatientDTO();
        public CarrierDTO Carrier { get; set; } = new CarrierDTO();
        public HospitalDTO Hospital { get; set; } = new HospitalDTO();
        public ProcedureDTO Procedure { get; set; } = new ProcedureDTO();
        public decimal OutstandingAmount { get; set; } = decimal.Zero;
        public decimal InsuranceResponsibilityAmount { get; set; } = decimal.Zero;
    }
}
