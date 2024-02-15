using Core.Entities;

namespace Entities.Concretes;

public class User : BaseEntity<int>
{
    public User()
    {
        
    }
    public User(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password)
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
    }
}
