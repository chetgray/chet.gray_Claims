namespace Claims.Business.Models.Interfaces
{
    public interface IProcedureModel
    {
        int? Id { get; set; }
        string Code { get; set; }
        string Name { get; set; }
    }
}
