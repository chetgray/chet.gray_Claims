namespace Claims.Business.Models.Interfaces
{
    public interface IProcedureModel : IBaseModel
    {
        string Code { get; set; }
        string Name { get; set; }
    }
}
