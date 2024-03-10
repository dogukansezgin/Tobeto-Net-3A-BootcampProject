using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
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
            var result = _authService.RegisterApplicant(applicantForRegister);
            return HandleDataResult(result); 
        }

        [HttpPost("Register: Employee")]
        public IActionResult Register(EmployeeForRegisterDto employeeForRegister)
        {
            var result = _authService.RegisterEmployee(employeeForRegister);
            return HandleDataResult(result);
        }

        [HttpPost("Register: Instructor")]
        public IActionResult Register(InstructorForRegisterDto instructorForRegister)
        {
            var result = _authService.RegisterInstructor(instructorForRegister);
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
