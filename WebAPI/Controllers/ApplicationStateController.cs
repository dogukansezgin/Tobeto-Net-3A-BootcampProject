using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateController : ControllerBase
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStateController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpPost]
        public CreateApplicationStateResponse Add(CreateApplicationStateRequest request)
        {
            return _applicationStateService.Add(request);
        }

        [HttpDelete]
        public DeleteApplicationStateResponse Delete(DeleteApplicationStateRequest request)
        {
            return _applicationStateService.Delete(request);
        }

        [HttpPut]
        public UpdateApplicationStateResponse Update(UpdateApplicationStateRequest request)
        {
            return _applicationStateService.Update(request);
        }

        [HttpGet]
        public List<GetAllApplicationStateResponse> GetAll()
        {
            return _applicationStateService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdApplicationStateResponse GetById(int id)
        {
            return _applicationStateService.GetById(id);
        }
    }
}
