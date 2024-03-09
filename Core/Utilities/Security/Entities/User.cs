using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class User : BaseEntity<Guid>
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }

    public User(Guid id, string email, byte[] passwordHash, byte[] passwordSalt, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity) : this()
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
    }
}
