using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class ProcedureModel : BaseModel, IProcedureModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
