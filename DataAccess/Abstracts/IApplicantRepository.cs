using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IApplicantRepository : ISyncRepository<Applicant, Guid>
{
}
