namespace Claims.Business.Models.Interfaces
{
    public interface ICarrierModel : IBaseModel
    {
        string Name { get; set; }
        IPhoneNumberModel CustomerServicePhoneNumber { get; set; }
    }
}
