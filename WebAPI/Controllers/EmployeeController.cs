using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public CreateEmployeeResponse Add(CreateEmployeeRequest request)
        {
            return _employeeService.Add(request);
        }

        [HttpDelete]
        public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request)
        {
            return _employeeService.Delete(request);
        }

        [HttpPut]
        public UpdateEmployeeResponse Update(UpdateEmployeeRequest request)
        {
            return _employeeService.Update(request);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_employeeService.GetById(id));
        }
    }
}
