using Business.Requests.Employees;
using Entities.Concretes;

namespace Business.Abstracts.Employees;

public interface IEmployeeValidator
{
    void CheckIfEmployeeNotExist(Employee employee);
    void CheckIfEmployeeIdExist(int id);
    Employee CheckEmployeeUpdate(Employee employee, UpdateEmployeeRequest request);
}
