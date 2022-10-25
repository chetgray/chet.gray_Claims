namespace Claims.Models
{
    internal class PhoneNumberModel : IPhoneNumberModel
    {
        public int? Id { get; }
        public string PhoneNumber { get; set; }
    }
}
