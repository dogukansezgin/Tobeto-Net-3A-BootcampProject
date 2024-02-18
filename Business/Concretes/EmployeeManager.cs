using Business.Requests.Employees;
using Business.Responses.Employees;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class EmployeeManager
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public CreateEmployeeResponse Add(CreateEmployeeRequest request)
    {
        Employee employee = new Employee();
        employee.UserName = request.UserName;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Position = request.Position;
        employee.DateOfBirth = request.DateOfBirth;
        employee.NationalIdentity = request.NationalIdentity;
        employee.Email = request.Email;
        employee.Password = request.Password;
        _employeeRepository.Add(employee);

        CreateEmployeeResponse response = new CreateEmployeeResponse();
        response.Id = employee.Id;
        response.UserName = employee.UserName;
        response.Position = employee.Position;
        response.CreatedDate = employee.CreatedDate;
        return response;
    }

    public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request)
    {
        Employee employee = new Employee()
        { Id = request.Id, UserName = request.UserName };
        _employeeRepository.Delete(employee);

        DeleteEmployeeResponse response = new DeleteEmployeeResponse();
        response.Id = employee.Id;
        response.UserName = employee.UserName;
        return response;
    }

    public List<GetAllEmployeeResponse> GetAll()
    {
        List<GetAllEmployeeResponse> employees = new();

        foreach (var employee in _employeeRepository.GetAll())
        {
            GetAllEmployeeResponse response = new();
            response.Id = employee.Id;
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.Position = employee.Position;
            response.DateOfBirth = employee.DateOfBirth;
            response.NationalIdentity = employee.NationalIdentity;
            response.Email = employee.Email;
            response.Password = employee.Password;
            response.CreatedDate = employee.CreatedDate;
            response.DeletedDate = employee.DeletedDate;
            response.UpdatedDate = employee.UpdatedDate;
            employees.Add(response);
        }
        return employees;
    }

    public GetByIdEmployeeResponse GetById(int id)
    {
        GetByIdEmployeeResponse response = new();
        Employee employee = _employeeRepository.Get(x => x.Id == id);
        response.Id = employee.Id;
        response.UserName = employee.UserName;
        response.FirstName = employee.FirstName;
        response.LastName = employee.LastName;
        response.Position = employee.Position;
        response.DateOfBirth = employee.DateOfBirth;
        response.NationalIdentity = employee.NationalIdentity;
        response.Email = employee.Email;
        response.Password = employee.Password;
        response.CreatedDate = employee.CreatedDate;
        response.DeletedDate = employee.DeletedDate;
        response.UpdatedDate = employee.UpdatedDate;
        return response;
    }

    public UpdateEmployeeResponse Update(UpdateEmployeeRequest request)
    {
        Employee employee = _employeeRepository.Get(u => u.Id == request.Id);
        employee.UserName = request.UserName ?? employee.UserName;
        employee.FirstName = request.FirstName ?? employee.FirstName;
        employee.LastName = request.LastName ?? employee.LastName;
        employee.Position = request.Position ?? employee.Position;
        employee.DateOfBirth = request.DateOfBirth ?? employee.DateOfBirth;
        employee.NationalIdentity = request.NationalIdentity ?? employee.NationalIdentity;
        employee.Email = request.Email ?? employee.Email;
        employee.Password = request.Password ?? employee.Password;
        employee.UpdatedDate = DateTime.UtcNow;
        _employeeRepository.Update(employee);

        UpdateEmployeeResponse response = new();
        response.UserName = employee.UserName;
        response.FirstName = employee.FirstName;
        response.LastName = employee.LastName;
        response.Position = employee.Position;
        response.DateOfBirth = employee.DateOfBirth;
        response.NationalIdentity = employee.NationalIdentity;
        response.Email = employee.Email;
        response.Password = employee.Password;
        response.UpdatedDate = (DateTime)employee.UpdatedDate;
        return response;
    }
}
