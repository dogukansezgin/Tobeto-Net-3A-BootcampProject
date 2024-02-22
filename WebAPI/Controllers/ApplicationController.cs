using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public CreateApplicationResponse Add(CreateApplicationRequest request)
        {
            return _applicationService.Add(request);
        }

        [HttpDelete]
        public DeleteApplicationResponse Delete(DeleteApplicationRequest request)
        {
            return _applicationService.Delete(request);
        }

        [HttpPut]
        public UpdateApplicationResponse Update(UpdateApplicationRequest request)
        {
            return _applicationService.Update(request);
        }

        [HttpGet]
        public List<GetAllApplicationResponse> GetAll()
        {
            return _applicationService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdApplicationResponse GetById(int id)
        {
            return _applicationService.GetById(id);
        }
    }
}
