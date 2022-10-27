using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class CarrierModel : BaseModel, ICarrierModel
    {
        public string Name { get; set; }
        public string CustomerServicePhoneNumber { get; set; }
    }
}
