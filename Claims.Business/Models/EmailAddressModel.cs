using Claims.Business.Models.Interfaces;

namespace Claims.Business.Models
{
    internal class EmailAddressModel : IEmailAddressModel
    {
        public int? Id { get; }
        public string EmailAddress { get; set; }
    }
}
