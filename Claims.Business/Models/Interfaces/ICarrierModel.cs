namespace Claims.Business.Models.Interfaces
{
    public interface ICarrierModel
    {
        int? Id { get; set; }
        string Name { get; set; }
        string CustomerServicePhoneNumber { get; set; }
    }
}
