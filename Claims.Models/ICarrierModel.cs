namespace Claims.Models
{
    public interface ICarrierModel : IBaseModel
    {
        string Name { get; set; }
        IPhoneNumberModel CustomerServicePhoneNumber { get; set; }
    }
}
