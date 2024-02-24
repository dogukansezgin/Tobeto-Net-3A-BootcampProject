using Business.Abstracts;
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

        [HttpDelete]
        public IActionResult Delete(DeleteApplicationStateRequest request)
        {
            return HandleDataResult(_applicationStateService.Delete(request));
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
        public IActionResult GetById(int id)
        {
            return HandleDataResult(_applicationStateService.GetById(id));
        }
    }
}
