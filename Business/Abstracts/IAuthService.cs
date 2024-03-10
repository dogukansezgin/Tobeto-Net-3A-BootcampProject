using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    DataResult<AccessToken> CreateAccessToken(User user);
    DataResult<AccessToken> Login(UserForLoginDto userForLoginDto);
    DataResult<AccessToken> RegisterApplicant(ApplicantForRegisterDto applicantForRegisterDto);
    DataResult<AccessToken> RegisterEmployee(EmployeeForRegisterDto employeeForRegisterDto);
    DataResult<AccessToken> RegisterInstructor(InstructorForRegisterDto instructorForRegisterDto);
}
