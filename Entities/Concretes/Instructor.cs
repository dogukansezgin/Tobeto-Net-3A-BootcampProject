using Core.Entities;
using System.Security.Cryptography;

namespace Entities.Concretes;

public class Instructor : User
{
    public string CompanyName { get; set; }
    public Instructor()
    {
        
    }

    public Instructor(string companyName)
    {
        CompanyName = companyName;
    }
}
