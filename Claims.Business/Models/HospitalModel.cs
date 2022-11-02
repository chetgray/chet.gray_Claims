using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class HospitalModel : IHospitalModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
