using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class StateModel : IBaseModel
    {
        public int? Id { get; }
        public string Name { get; set; }
    }
}
