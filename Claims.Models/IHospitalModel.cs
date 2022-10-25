namespace Claims.Models
{
    public interface IHospitalModel : IBaseModel
    {
        string Name { get; set; }
        IAddressModel Address { get; set; }
    }
}
