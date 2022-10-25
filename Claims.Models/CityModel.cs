namespace Claims.Models
{
    public class CityModel : IBaseModel
    {
        public int? Id { get; }
        public string Name { get; set; }
        public StateModel State { get; set; }
    }
}
