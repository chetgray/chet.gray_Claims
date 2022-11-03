using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class CarrierModel : ICarrierModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CustomerServicePhoneNumber { get; set; }
    }
}
