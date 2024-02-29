using AutoMapper;
using Business.Abstracts.Employees;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Employees;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeValidator _employeeValidator;
    private readonly IMapper _mapper;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeeValidator employeeValidator)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _employeeValidator = employeeValidator;
    }

    public IDataResult<CreateEmployeeResponse> Add(CreateEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        _employeeValidator.CheckIfEmployeeNotExist(employee);
        _employeeRepository.Add(employee);

        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
        return new SuccessDataResult<CreateEmployeeResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _employeeValidator.CheckIfEmployeeIdExist(id);
        Employee employee = _employeeRepository.Get(x => x.Id == id);
        _employeeRepository.Delete(employee);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllEmployeeResponse>> GetAll()
    {
        List<Employee> employees = _employeeRepository.GetAll();
        List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdEmployeeResponse> GetById(int id)
    {
        _employeeValidator.CheckIfEmployeeIdExist(id);
        Employee employee = _employeeRepository.Get(x => x.Id == id);
        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);
        return new SuccessDataResult<GetByIdEmployeeResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request)
    {
        _employeeValidator.CheckIfEmployeeIdExist(request.Id);
        Employee employee = _employeeRepository.Get(u => u.Id == request.Id);
        
        _employeeValidator.CheckEmployeeUpdate(employee, request);
        _employeeRepository.Update(employee);

        UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
        return new SuccessDataResult<UpdateEmployeeResponse>(response, "Updated Succesfully");
    }
}
