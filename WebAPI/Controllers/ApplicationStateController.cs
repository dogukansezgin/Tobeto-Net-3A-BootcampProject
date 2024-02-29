using Business.Abstracts.ApplicatonStates;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateController : BaseController
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStateController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpPost]
        public IActionResult Add(CreateApplicationStateRequest request)
        {
            return HandleDataResult(_applicationStateService.Add(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return HandleResult(_applicationStateService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateApplicationStateRequest request)
        {
            return HandleDataResult(_applicationStateService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_applicationStateService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return HandleDataResult(_applicationStateService.GetById(id));
        }
    }
}
