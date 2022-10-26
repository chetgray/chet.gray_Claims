using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    internal class AddressModel : IAddressModel
    {
        public int? Id { get; }
        public string StreetAddress { get; set; }
        public CityModel City { get; set; }
        public ZipModel Zip { get; set; }
    }
}
