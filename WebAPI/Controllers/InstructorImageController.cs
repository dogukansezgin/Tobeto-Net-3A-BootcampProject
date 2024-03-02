using Business.Abstracts;
using Business.Requests.InstructorImages;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorImageController : BaseController
    {
        private readonly IInstructorImageService _instructorImageService;

        public InstructorImageController(IInstructorImageService instructorImageService)
        {
            _instructorImageService = instructorImageService;
        }

        [HttpPost]
        public IActionResult Add(CreateInstructorImageRequest request)
        {
            return HandleDataResult(_instructorImageService.Add(request));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return HandleResult(_instructorImageService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateInstructorImageRequest request)
        {
            return HandleDataResult(_instructorImageService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_instructorImageService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return HandleDataResult(_instructorImageService.GetById(id));
        }
    }
}
