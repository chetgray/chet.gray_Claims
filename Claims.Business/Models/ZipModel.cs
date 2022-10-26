using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class ZipModel : IBaseModel
    {
        public int? Id { get; }
        public string Code { get; set; }
    }
}
