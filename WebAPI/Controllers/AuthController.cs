using Business.Abstracts;
using Business.Requests.Applicants;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register: Applicant")]
        public IActionResult Register(ApplicantForRegisterDto applicantForRegister)
        {
            var result = _authService.Register(applicantForRegister);
            return HandleDataResult(result); 
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            return HandleDataResult(result);
        }
    }
}
