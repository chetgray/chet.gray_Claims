namespace Claims.Business.Models.Interfaces
{
    public interface IHospitalModel : IBaseModel
    {
        string Name { get; set; }
        IAddressModel Address { get; set; }
    }
}
