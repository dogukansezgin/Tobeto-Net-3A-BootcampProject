using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public IActionResult Add(CreateApplicationRequest request)
        {
            return HandleDataResult(_applicationService.Add(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return HandleResult(_applicationService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateApplicationRequest request)
        {
            return HandleDataResult(_applicationService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_applicationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return HandleDataResult(_applicationService.GetById(id));
        }
    }
}
