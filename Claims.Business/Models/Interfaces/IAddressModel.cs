namespace Claims.Business.Models.Interfaces
{
    public interface IAddressModel : IBaseModel
    {
        string StreetAddress { get; set; }
        CityModel City { get; set; }
        ZipModel Zip { get; set; }
    }
}
