using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public int? Id { get; set; }
    }
}
