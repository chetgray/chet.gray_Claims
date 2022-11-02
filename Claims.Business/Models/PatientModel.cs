using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class PatientModel : IPatientModel
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
