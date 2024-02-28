using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : BaseController
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }
        [HttpPost]
        public IActionResult Add(CreateBootcampStateRequest request)
        {
            return HandleDataResult(_bootcampStateService.Add(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return HandleResult(_bootcampStateService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateBootcampStateRequest request)
        {
            return HandleDataResult(_bootcampStateService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_bootcampStateService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return HandleDataResult(_bootcampStateService.GetById(id));
        }
    }
}
