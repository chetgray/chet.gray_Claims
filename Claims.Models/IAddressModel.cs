namespace Claims.Models
{
    public interface IAddressModel : IBaseModel
    {
        string StreetAddress { get; set; }
        CityModel City { get; set; }
        ZipModel Zip { get; set; }
    }
}
