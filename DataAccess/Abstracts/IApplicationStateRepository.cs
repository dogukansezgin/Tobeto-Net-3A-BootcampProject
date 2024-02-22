using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IApplicationStateRepository : ISyncRepository<ApplicationState, int>
{
}
