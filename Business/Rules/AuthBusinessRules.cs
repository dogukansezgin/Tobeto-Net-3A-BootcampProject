using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void UserPasswordShouldMatch(Guid id, string password)
    {
        User user = _userRepository.Get(x => x.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Email or Password missing.");
    }
    public void UserEmailShouldExist(string email)
    {
        var isExist = _userRepository.Get(x => x.Email.Trim() == email.Trim()) is null;
        if (isExist) throw new BusinessException("Email or Password missing.");
    }

    public void UserEmailShouldNotExist(string email)
    {
        var isExist = _userRepository.Get(x => x.Email.Trim() == email.Trim()) is not null;
        if (isExist) throw new BusinessException("This mail already used.");
    }

    public void UserShouldExist(User user)
    {
        if (user is null) throw new BusinessException("Email or Password missing.");
    }

    public void UserNationalIdShouldNotExist(string nationalIdentity)
    {
        var isExist = _userRepository.Get(x => x.NationalIdentity.Trim() == nationalIdentity.Trim()) is not null;
        if (isExist) throw new BusinessException("This ID number is already registered.");
    }

    public void UserUserNameShouldNotExist(string userName)
    {
        var isExist = _userRepository.Get(x => x.UserName.Trim() == userName.Trim()) is not null;
        if (isExist) throw new BusinessException("This Username is already registered.");
    }
}
