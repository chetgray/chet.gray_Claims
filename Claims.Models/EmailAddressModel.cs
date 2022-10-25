namespace Claims.Models
{
    internal class EmailAddressModel : IEmailAddressModel
    {
        public int? Id { get; }
        public string EmailAddress { get; set; }
    }
}
