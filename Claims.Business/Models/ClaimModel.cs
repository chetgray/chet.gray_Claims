using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class ClaimModel : IClaimModel
    {
        public int? Id { get; set; }
        public IPatientModel Patient { get; set; } = new PatientModel();
        public ICarrierModel Carrier { get; set; } = new CarrierModel();
        public IHospitalModel Hospital { get; set; } = new HospitalModel();
        public IProcedureModel Procedure { get; set; } = new ProcedureModel();
        public decimal OutstandingAmount { get; set; } = decimal.Zero;
        public decimal InsuranceResponsibilityAmount { get; set; } = decimal.Zero;
        public decimal PatientResponsibilityAmount
        {
            get => OutstandingAmount - InsuranceResponsibilityAmount;
        }
    }
}
