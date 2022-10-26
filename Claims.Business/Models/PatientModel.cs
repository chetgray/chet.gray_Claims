using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    internal class PatientModel : IPatientModel
    {
        public int? Id { get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public IAddressModel Address { get; set; }
        public IPhoneNumberModel PhoneNumber { get; set; }
        public IEmailAddressModel EmailAddress { get; set; }
    }
}
