namespace Claims.Models
{
    public interface IProcedureModel : IBaseModel
    {
        string Code { get; set; }
        string Name { get; set; }
    }
}
