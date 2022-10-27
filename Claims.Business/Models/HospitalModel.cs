using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class HospitalModel : BaseModel, IHospitalModel
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
