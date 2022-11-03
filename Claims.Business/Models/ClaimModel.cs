using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class ClaimModel : IClaimModel
    {
        public int? Id { get; set; }
        public IPatientModel Patient { get; set; }
        public ICarrierModel Carrier { get; set; }
        public IHospitalModel Hospital { get; set; }
        public IProcedureModel Procedure { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal InsuranceResponsibilityAmount { get; set; }
        public decimal PatientResponsibilityAmount
        {
            get => OutstandingAmount - InsuranceResponsibilityAmount;
        }
    }
}
