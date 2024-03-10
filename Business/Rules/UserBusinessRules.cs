using Business.Requests.Users;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User CheckUserUpdate(User user, UpdateUserRequest request)
    {
        user.UserName = request.UserName != "string" || request.UserName != null ? request.UserName : user.UserName;
        user.FirstName = request.FirstName != "string" || request.FirstName != null ? request.FirstName : user.FirstName;
        user.LastName = request.LastName != "string" || request.LastName != null ? request.LastName : user.LastName;
        user.NationalIdentity = request.NationalIdentity != "string" || request.NationalIdentity != null ? request.NationalIdentity : user.NationalIdentity;
        user.Email = request.Email != "string" || request.Email != null ? request.Email : user.Email;
        var passwordHash = request.PasswordHash.ToString();
        user.PasswordHash = passwordHash != "string" || request.PasswordHash != null ? request.PasswordHash : user.PasswordHash;
        var passwordSalt = request.PasswordSalt.ToString();
        user.PasswordSalt = passwordSalt != "string" || request.PasswordSalt != null ? request.PasswordSalt : user.PasswordSalt;
        //user.DateOfBirth eklenecek.

        user.UpdatedDate = DateTime.UtcNow;
        return user;
    }

    public void CheckIfUserIdExist(Guid id)
    {
        var isExist = _userRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("User is not exists.");
    }

    public void CheckIfUserEmailExist(string email)
    {
        var isExist = _userRepository.Get(x => x.Email.Trim() == email.Trim()) is null;
        if (isExist) throw new BusinessException("Email or Password missing.");
    }

    public void CheckIfUserEmailNotExist(string email)
    {
        var isExist = _userRepository.Get(x => x.Email.Trim() == email.Trim()) is not null;
        if (isExist) throw new BusinessException("This mail already used.");
    }

    public void CheckIfUserExist(User user)
    {
        if (user is null) throw new BusinessException("Email or Password missing.");
    }

    public void CheckIfUserNotExist(User user)
    {
        var isExistId = _userRepository.Get(x => x.Id == user.Id) is not null;
        var isExistUserName = _userRepository.Get(x => x.UserName.Trim() == user.UserName.Trim()) is not null;
        var isExistNationalId = _userRepository.Get(x => x.NationalIdentity.Trim() == user.NationalIdentity.Trim()) is not null;
        var isExistEmail = _userRepository.Get(x => x.Email.Trim() == user.Email.Trim()) is not null;
        if (isExistId || isExistUserName || isExistNationalId || isExistEmail) throw new BusinessException("User already exists.");
    }

    public void CheckIfUserPasswordMatch(Guid id, string password)
    {
        User user = _userRepository.Get(x => x.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Email or Password missing.");
    }
}
