using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBootcampStateRepository : ISyncRepository<BootcampState, int>
{
}
