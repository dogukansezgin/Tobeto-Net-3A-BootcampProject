using Business.Requests.Applicants;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    DataResult<AccessToken> Login(UserForLoginDto userForLoginDto);
    DataResult<AccessToken> Register(ApplicantForRegisterDto applicantForRegisterDto);
    DataResult<AccessToken> CreateAccessToken(User user);

}
