using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
    }

    public DataResult<AccessToken> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = _userOperationClaimRepository.Query().AsNoTracking()
            .Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.Id,
                Name = x.OperationClaim.Name
            }).ToList();

        var accessToken = _tokenHelper.CreateToken(user, claims);

        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }

    public DataResult<AccessToken> Login(UserForLoginDto userForLoginDto)
    {
        var user = _userService.GetByMail(userForLoginDto.Email);
        _userBusinessRules.CheckIfUserExist(user.Data);
        _userBusinessRules.CheckIfUserEmailExist(userForLoginDto.Email);
        _userBusinessRules.CheckIfUserPasswordMatch(user.Data.Id, userForLoginDto.Password);

        var createAccessToken = CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }

    public DataResult<AccessToken> Register(ApplicantForRegisterDto applicantForRegisterDto)
    {
        _userBusinessRules.CheckIfUserEmailNotExist(applicantForRegisterDto.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(applicantForRegisterDto.Password, out passwordHash, out passwordSalt);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = applicantForRegisterDto.Email,
            UserName = applicantForRegisterDto.UserName,
            FirstName = applicantForRegisterDto.FirstName,
            LastName = applicantForRegisterDto.LastName,
            DateOfBirth = applicantForRegisterDto.DateOfBirth,
            NationalIdentity = applicantForRegisterDto.NationalIdentity,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        _userRepository.Add(user);
        var createAccessToken = CreateAccessToken(user);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }
}
