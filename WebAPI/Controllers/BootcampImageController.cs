using Business.Abstracts;
using Business.Requests.BootcampImages;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampImageController : BaseController
    {
        private readonly IBootcampImageService _bootcampImageService;

        public BootcampImageController(IBootcampImageService bootcampImageService)
        {
            _bootcampImageService = bootcampImageService;
        }

        [HttpPost]
        public IActionResult Add(CreateBootcampImageRequest request)
        {
            return HandleDataResult(_bootcampImageService.Add(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return HandleResult(_bootcampImageService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateBootcampImageRequest request)
        {
            return HandleDataResult(_bootcampImageService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_bootcampImageService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return HandleDataResult(_bootcampImageService.GetById(id));
        }
    }
}
