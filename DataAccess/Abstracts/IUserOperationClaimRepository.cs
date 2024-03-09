using Core.DataAccess;
using Core.Utilities.Security.Entities;

namespace DataAccess.Abstracts;

public interface IUserOperationClaimRepository : ISyncRepository<UserOperationClaim, int>
{
}
