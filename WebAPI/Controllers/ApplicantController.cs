﻿using Business.Abstracts;
using Business.Requests.Applicants;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost]
        public IActionResult Add(CreateApplicantRequest request)
        {
            return HandleDataResult(_applicantService.Add(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return HandleResult(_applicantService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateApplicantRequest request)
        {
            return HandleDataResult(_applicantService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_applicantService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return HandleDataResult(_applicantService.GetById(id));
        }
    }
}
