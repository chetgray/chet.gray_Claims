namespace Claims.Business.Models.Interfaces
{
    public interface IClaimModel : IBaseModel
    {
        IPatientModel Patient { get; set; }
        ICarrierModel Carrier { get; set; }
        IHospitalModel Hospital { get; set; }
        IProcedureModel Procedure { get; set; }
        decimal OutstandingAmount { get; set; }
        decimal InsuranceResponsibilityAmount { get; set; }
        decimal PatientResponsibilityAmount { get; }
    }
}
