using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class CityModel : IBaseModel
    {
        public int? Id { get; }
        public string Name { get; set; }
        public StateModel State { get; set; }
    }
}
