using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    internal class ProcedureModel : IProcedureModel
    {
        public int? Id { get; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
