using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class User : BaseEntity<Guid>
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public User()
    {
        
    }

    public User(Guid id, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
