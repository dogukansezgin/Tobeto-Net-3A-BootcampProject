﻿using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly EmployeeBusinessRules _employeeBusinessRules;
    private readonly IMapper _mapper;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _employeeBusinessRules = employeeBusinessRules;
    }

    public IDataResult<CreateEmployeeResponse> Add(CreateEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        _employeeBusinessRules.CheckIfEmployeeNotExist(employee);
        _employeeRepository.Add(employee);

        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
        return new SuccessDataResult<CreateEmployeeResponse>(response, EmployeeMessages.EmployeeAdded);
    }

    public IResult Delete(Guid id)
    {
        _employeeBusinessRules.CheckIfEmployeeIdExist(id);
        Employee employee = _employeeRepository.Get(x => x.Id == id);
        _employeeRepository.Delete(employee);
        return new SuccessResult(EmployeeMessages.EmployeeDeleted);
    }

    public IDataResult<List<GetAllEmployeeResponse>> GetAll()
    {
        List<Employee> employees = _employeeRepository.GetAll();
        List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, EmployeeMessages.EmployeeListed);
    }

    public IDataResult<GetByIdEmployeeResponse> GetById(Guid id)
    {
        _employeeBusinessRules.CheckIfEmployeeIdExist(id);
        Employee employee = _employeeRepository.Get(x => x.Id == id);
        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);
        return new SuccessDataResult<GetByIdEmployeeResponse>(response, EmployeeMessages.EmployeeListed);
    }

    public IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request)
    {
        _employeeBusinessRules.CheckIfEmployeeIdExist(request.Id);
        Employee employee = _employeeRepository.Get(u => u.Id == request.Id);

        _employeeBusinessRules.CheckEmployeeUpdate(employee, request);
        _employeeRepository.Update(employee);

        UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
        return new SuccessDataResult<UpdateEmployeeResponse>(response, EmployeeMessages.EmployeeUpdated);
    }
}
