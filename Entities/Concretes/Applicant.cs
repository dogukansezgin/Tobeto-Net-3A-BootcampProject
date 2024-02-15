using Core.Entities;

namespace Entities.Concretes;

public class Applicant : BaseEntity<int>
{
    public string About { get; set; }
    public Applicant()
    {

    }

    public Applicant(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string about)
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
        About = about;
    }
}
