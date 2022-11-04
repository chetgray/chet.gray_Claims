using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class HospitalModel : IHospitalModel
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }
}
