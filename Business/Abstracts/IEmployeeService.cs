using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IEmployeeService
{
    IDataResult<CreateEmployeeResponse> Add(CreateEmployeeRequest request);
    IResult Delete(Guid id);
    IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request);
    IDataResult<GetByIdEmployeeResponse> GetById(Guid id);
    IDataResult<List<GetAllEmployeeResponse>> GetAll();
}
