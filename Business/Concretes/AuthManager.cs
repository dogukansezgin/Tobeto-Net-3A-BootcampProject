using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserService _userService;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IInstructorRepository _instructorRepository;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IApplicantRepository applicantRepository, AuthBusinessRules authBusinessRules, IEmployeeRepository employeeRepository, IInstructorRepository instructorRepository)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _authBusinessRules = authBusinessRules;
        _applicantRepository = applicantRepository;
        _employeeRepository = employeeRepository;
        _instructorRepository = instructorRepository;
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
        _authBusinessRules.UserShouldExist(user.Data);
        _authBusinessRules.UserEmailShouldExist(userForLoginDto.Email);
        _authBusinessRules.UserPasswordShouldMatch(user.Data.Id, userForLoginDto.Password);

        var createAccessToken = CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }

    public DataResult<AccessToken> RegisterApplicant(ApplicantForRegisterDto applicantForRegisterDto)
    {
        _authBusinessRules.UserEmailShouldNotExist(applicantForRegisterDto.Email);
        _authBusinessRules.UserNationalIdShouldNotExist(applicantForRegisterDto.NationalIdentity);
        _authBusinessRules.UserUserNameShouldNotExist(applicantForRegisterDto.UserName);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(applicantForRegisterDto.Password, out passwordHash, out passwordSalt);

        var applicant = new Applicant
        {
            Id = Guid.NewGuid(),
            Email = applicantForRegisterDto.Email,
            UserName = applicantForRegisterDto.UserName,
            FirstName = applicantForRegisterDto.FirstName,
            LastName = applicantForRegisterDto.LastName,
            DateOfBirth = applicantForRegisterDto.DateOfBirth,
            NationalIdentity = applicantForRegisterDto.NationalIdentity,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            About = applicantForRegisterDto.About
        };
        _applicantRepository.Add(applicant);
        var createAccessToken = CreateAccessToken(applicant);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    public DataResult<AccessToken> RegisterEmployee(EmployeeForRegisterDto employeeForRegisterDto)
    {
        _authBusinessRules.UserEmailShouldNotExist(employeeForRegisterDto.Email);
        _authBusinessRules.UserNationalIdShouldNotExist(employeeForRegisterDto.NationalIdentity);
        _authBusinessRules.UserUserNameShouldNotExist(employeeForRegisterDto.UserName);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(employeeForRegisterDto.Password, out passwordHash, out passwordSalt);

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Email = employeeForRegisterDto.Email,
            UserName = employeeForRegisterDto.UserName,
            FirstName = employeeForRegisterDto.FirstName,
            LastName = employeeForRegisterDto.LastName,
            DateOfBirth = employeeForRegisterDto.DateOfBirth,
            NationalIdentity = employeeForRegisterDto.NationalIdentity,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Position = employeeForRegisterDto.Position
        };
        _employeeRepository.Add(employee);
        var createAccessToken = CreateAccessToken(employee);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }

    public DataResult<AccessToken> RegisterInstructor(InstructorForRegisterDto instructorForRegisterDto)
    {
        _authBusinessRules.UserEmailShouldNotExist(instructorForRegisterDto.Email);
        _authBusinessRules.UserNationalIdShouldNotExist(instructorForRegisterDto.NationalIdentity);
        _authBusinessRules.UserUserNameShouldNotExist(instructorForRegisterDto.UserName);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(instructorForRegisterDto.Password, out passwordHash, out passwordSalt);

        var instructor = new Instructor
        {
            Id = Guid.NewGuid(),
            Email = instructorForRegisterDto.Email,
            UserName = instructorForRegisterDto.UserName,
            FirstName = instructorForRegisterDto.FirstName,
            LastName = instructorForRegisterDto.LastName,
            DateOfBirth = instructorForRegisterDto.DateOfBirth,
            NationalIdentity = instructorForRegisterDto.NationalIdentity,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CompanyName = instructorForRegisterDto.CompanyName,
        };
        _instructorRepository.Add(instructor);
        var createAccessToken = CreateAccessToken(instructor);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Register Success");
    }
}
