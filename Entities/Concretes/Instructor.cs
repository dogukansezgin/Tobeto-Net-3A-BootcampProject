using Core.Entities;
using System.Security.Cryptography;

namespace Entities.Concretes;

public class Instructor : BaseEntity<int>
{
    public string CompanyName { get; set; }
    public Instructor()
    {
        
    }

    public Instructor(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string companyName)
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
        CompanyName = companyName;
    }
}
