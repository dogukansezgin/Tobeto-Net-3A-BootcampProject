using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;
public interface IBlacklistRepository : ISyncRepository<Blacklist, int>
{
}
