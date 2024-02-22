﻿using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public CreateInstructorResponse Add(CreateInstructorRequest request)
        {
            return _instructorService.Add(request);
        }

        [HttpDelete]
        public DeleteInstructorResponse Delete(DeleteInstructorRequest request)
        {
            return _instructorService.Delete(request);
        }

        [HttpPut]
        public UpdateInstructorResponse Update(UpdateInstructorRequest request)
        {
            return _instructorService.Update(request);
        }

        [HttpGet]
        public List<GetAllInstructorResponse> GetAll()
        {
            return _instructorService.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdInstructorResponse GetById(int id)
        {
            return _instructorService.GetById(id);
        }
    }
}