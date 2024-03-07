using Business.Abstracts;
using Business.Requests.Employees;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Add(CreateEmployeeRequest request)
        {
            return HandleDataResult(_employeeService.Add(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            return HandleResult(_employeeService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateEmployeeRequest request)
        {
            return HandleDataResult(_employeeService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return HandleDataResult(_employeeService.GetById(id));
        }
    }
}
