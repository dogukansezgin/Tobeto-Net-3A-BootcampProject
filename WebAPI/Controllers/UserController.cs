using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstracts;
using Entities.Concretes;
using Business.Requests.Users;
using Business.Responses.Users;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public CreateUserResponse Add(CreateUserRequest request)
        {
            return _userService.Add(request);
        }

        [HttpDelete]
        public DeleteUserResponse Delete(DeleteUserRequest request)
        {
            return _userService.Delete(request);
        }

        [HttpPut]
        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            return _userService.Update(request);
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }
    }
}
