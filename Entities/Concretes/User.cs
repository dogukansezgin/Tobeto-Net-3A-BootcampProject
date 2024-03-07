namespace Entities.Concretes;

public class User : Core.Utilities.Security.Entities.User
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }

    public User()
    {

    }

    public User(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
    }
}
