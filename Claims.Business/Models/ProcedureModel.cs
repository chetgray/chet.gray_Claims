using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    public class ProcedureModel : IProcedureModel
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
