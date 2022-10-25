namespace Claims.Models
{
    public interface IPatientModel : IBaseModel
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        IAddressModel Address { get; set; }
        IPhoneNumberModel PhoneNumber { get; set; }
        IEmailAddressModel EmailAddress { get; set; }
    }
}
