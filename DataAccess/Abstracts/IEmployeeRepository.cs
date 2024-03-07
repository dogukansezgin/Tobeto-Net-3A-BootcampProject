using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IEmployeeRepository : ISyncRepository<Employee, Guid>
{
}
