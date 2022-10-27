namespace Claims.Business.Models.Interfaces
{
    public interface IHospitalModel : IBaseModel
    {
        string Name { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}
