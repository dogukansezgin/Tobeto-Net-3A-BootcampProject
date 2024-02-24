using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : BaseController
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost]
        public IActionResult Add(CreateBootcampRequest request)
        {
            return HandleDataResult(_bootcampService.Add(request));
        }

        [HttpDelete]
        public IActionResult Delete(DeleteBootcampRequest request)
        {
            return HandleDataResult(_bootcampService.Delete(request));
        }

        [HttpPut]
        public IActionResult Update(UpdateBootcampRequest request)
        {
            return HandleDataResult(_bootcampService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_bootcampService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return HandleDataResult(_bootcampService.GetById(id));
        }
    }
}
