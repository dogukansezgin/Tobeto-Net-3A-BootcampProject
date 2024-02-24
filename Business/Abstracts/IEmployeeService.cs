using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IEmployeeService
{
    IDataResult<CreateEmployeeResponse> Add(CreateEmployeeRequest request);
    IDataResult<DeleteEmployeeResponse> Delete(DeleteEmployeeRequest request);
    IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request);
    IDataResult<GetByIdEmployeeResponse> GetById(int id);
    IDataResult<List<GetAllEmployeeResponse>> GetAll();
}
