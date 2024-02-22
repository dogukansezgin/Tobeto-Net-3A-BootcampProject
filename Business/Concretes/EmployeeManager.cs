using Business.Requests.Employees;
using Business.Responses.Employees;
using DataAccess.Abstracts;
using Entities.Concretes;
using Business.Abstracts;
using AutoMapper;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public CreateEmployeeResponse Add(CreateEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        _employeeRepository.Add(employee);

        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
        return response;
    }

    public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        _employeeRepository.Delete(employee);

        DeleteEmployeeResponse response = _mapper.Map<DeleteEmployeeResponse>(employee);
        return response;
    }

    public List<GetAllEmployeeResponse> GetAll()
    {
        List<Employee> employees = _employeeRepository.GetAll();
        List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);
        return responses;
    }

    public GetByIdEmployeeResponse GetById(int id)
    {
        Employee employee = _employeeRepository.Get(x => x.Id == id);
        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);
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

        UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
        return response;
    }
}
