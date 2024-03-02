using Business.Abstracts;
using Business.Requests.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add(CreateUserRequest request)
        {
            return HandleDataResult(_userService.Add(request));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return HandleResult(_userService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateUserRequest request)
        {
            return HandleDataResult(_userService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return HandleDataResult(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return HandleDataResult(_userService.GetById(id));
        }
    }
}
