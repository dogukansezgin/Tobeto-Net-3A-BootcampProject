using Business.Abstracts;
using Business.Requests.Instructors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public IActionResult Add(CreateInstructorRequest request)
        {
            return HandleDataResult(_instructorService.Add(request));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return HandleResult(_instructorService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateInstructorRequest request)
        {
            return HandleDataResult(_instructorService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_instructorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return HandleDataResult(_instructorService.GetById(id));
        }
    }
}
