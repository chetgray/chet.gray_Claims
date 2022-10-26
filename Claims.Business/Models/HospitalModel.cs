using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    internal class HospitalModel : IHospitalModel
    {
        public int? Id { get; }
        public string Name { get; set; }
        public IAddressModel Address { get; set; }
        public IPhoneNumberModel CustomerServicePhoneNumber { get; set; }
    }
}
