using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IApplicationRepository : ISyncRepository<Application, int>
{
}
