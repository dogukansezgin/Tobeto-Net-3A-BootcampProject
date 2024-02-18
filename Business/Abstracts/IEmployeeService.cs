using Business.Requests.Employees;
using Business.Responses.Employees;

namespace Business.Abstracts;

public interface IEmployeeService
{
    CreateEmployeeResponse Add(CreateEmployeeRequest request);
    DeleteEmployeeResponse Delete(DeleteEmployeeRequest request);
    UpdateEmployeeResponse Update(UpdateEmployeeRequest request);
    GetByIdEmployeeResponse GetById(int id);
    List<GetAllEmployeeResponse> GetAll();
}
