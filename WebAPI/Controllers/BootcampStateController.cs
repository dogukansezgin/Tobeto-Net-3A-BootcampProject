using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : ControllerBase
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }
        [HttpPost]
        public CreateBootcampStateResponse Add(CreateBootcampStateRequest request)
        {
            return _bootcampStateService.Add(request);
        }

        [HttpDelete]
        public DeleteBootcampStateResponse Delete(DeleteBootcampStateRequest request)
        {
            return _bootcampStateService.Delete(request);
        }

        [HttpPut]
        public UpdateBootcampStateResponse Update(UpdateBootcampStateRequest request)
        {
            return _bootcampStateService.Update(request);
        }

        [HttpGet]
        public List<GetAllBootcampStateResponse> GetAll()
        {
            return _bootcampStateService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdBootcampStateResponse GetById(int id)
        {
            return _bootcampStateService.GetById(id);
        }
    }
}
