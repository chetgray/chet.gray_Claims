namespace Claims.Models
{
    internal class CarrierModel : ICarrierModel
    {
        public int? Id { get; }
        public string Name { get; set; }
        public IPhoneNumberModel CustomerServicePhoneNumber { get; set; }
    }
}
