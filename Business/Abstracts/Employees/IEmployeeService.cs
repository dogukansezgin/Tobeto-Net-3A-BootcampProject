using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;

namespace Business.Abstracts.Employees;

public interface IEmployeeService
{
    IDataResult<CreateEmployeeResponse> Add(CreateEmployeeRequest request);
    IResult Delete(int id);
    IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request);
    IDataResult<GetByIdEmployeeResponse> GetById(int id);
    IDataResult<List<GetAllEmployeeResponse>> GetAll();
}
