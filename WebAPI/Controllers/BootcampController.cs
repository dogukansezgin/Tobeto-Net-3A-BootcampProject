using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }
        [HttpPost]
        public CreateBootcampResponse Add(CreateBootcampRequest request)
        {
            return _bootcampService.Add(request);
        }

        [HttpDelete]
        public DeleteBootcampResponse Delete(DeleteBootcampRequest request)
        {
            return _bootcampService.Delete(request);
        }

        [HttpPut]
        public UpdateBootcampResponse Update(UpdateBootcampRequest request)
        {
            return _bootcampService.Update(request);
        }

        [HttpGet]
        public List<GetAllBootcampResponse> GetAll()
        {
            return _bootcampService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdBootcampResponse GetById(int id)
        {
            return _bootcampService.GetById(id);
        }
    }
}
