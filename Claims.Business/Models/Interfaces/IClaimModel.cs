namespace Claims.Business.Models.Interfaces
{
    public interface IClaimModel
    {
        int? Id { get; set; }
        IPatientModel Patient { get; set; }
        ICarrierModel Carrier { get; set; }
        IHospitalModel Hospital { get; set; }
        IProcedureModel Procedure { get; set; }
        decimal OutstandingAmount { get; set; }
        decimal InsuranceResponsibilityAmount { get; set; }
        decimal PatientResponsibilityAmount { get; }
    }
}
