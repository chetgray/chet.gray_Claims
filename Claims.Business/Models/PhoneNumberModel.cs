using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    internal class PhoneNumberModel : IPhoneNumberModel
    {
        public int? Id { get; }
        public string PhoneNumber { get; set; }
    }
}
