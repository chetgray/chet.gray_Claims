namespace Claims.Business.Models.Interfaces
{
    public interface IPatientModel : IBaseModel
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string PhoneNumber { get; set; }
        string EmailAddress { get; set; }
    }
}
