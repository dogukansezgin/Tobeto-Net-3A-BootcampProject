﻿using Business.Requests.Employees;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Employee CheckEmployeeUpdate(Employee employee, UpdateEmployeeRequest request)
    {
        employee.UserName = request.UserName != "string" || request.UserName != null ? request.UserName : employee.UserName;
        employee.FirstName = request.FirstName != "string" || request.FirstName != null ? request.FirstName : employee.FirstName;
        employee.LastName = request.LastName != "string" || request.LastName != null ? request.LastName : employee.LastName;
        employee.Position = request.Position != "string" || request.Position != null ? request.Position : employee.Position;
        employee.NationalIdentity = request.NationalIdentity != "string" || request.NationalIdentity != null ? request.NationalIdentity : employee.NationalIdentity;
        employee.Email = request.Email != "string" || request.Email != null ? request.Email : employee.Email;
        var passwordHash = request.PasswordHash.ToString();
        employee.PasswordHash = passwordHash != "string" || request.PasswordHash != null ? request.PasswordHash : employee.PasswordHash;
        var passwordSalt = request.PasswordSalt.ToString();
        employee.PasswordSalt = passwordSalt != "string" || request.PasswordSalt != null ? request.PasswordSalt : employee.PasswordSalt;
        //employee.DateOfBirth eklenecek.

        employee.UpdatedDate = DateTime.UtcNow;
        return employee;
    }

    public void CheckIfEmployeeIdExist(Guid id)
    {
        var isExist = _employeeRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Employee is not exists.");
    }

    public void CheckIfEmployeeNotExist(Employee employee)
    {
        var isExistId = _employeeRepository.Get(x => x.Id == employee.Id) is not null;
        var isExistUserName = _employeeRepository.Get(x => x.UserName.Trim() == employee.UserName.Trim()) is not null;
        var isExistNationalId = _employeeRepository.Get(x => x.NationalIdentity.Trim() == employee.NationalIdentity.Trim()) is not null;
        var isExistEmail = _employeeRepository.Get(x => x.Email.Trim() == employee.Email.Trim()) is not null;
        if (isExistId || isExistUserName || isExistNationalId || isExistEmail) throw new BusinessException("Employee already exists.");
    }
}
