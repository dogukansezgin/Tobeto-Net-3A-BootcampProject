using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost]
        public CreateApplicantResponse Add(CreateApplicantRequest request)
        {
            return _applicantService.Add(request);
        }

        [HttpDelete]
        public DeleteApplicantResponse Delete(DeleteApplicantRequest request)
        {
            return _applicantService.Delete(request);
        }

        [HttpPut]
        public UpdateApplicantResponse Update(UpdateApplicantRequest request)
        {
            return _applicantService.Update(request);
        }

        [HttpGet]
        public List<GetAllApplicantResponse> GetAll()
        {
            return _applicantService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdApplicantResponse GetById(int id)
        {
            return _applicantService.GetById(id);
        }
    }
}
