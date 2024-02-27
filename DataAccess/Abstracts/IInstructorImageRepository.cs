using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IInstructorImageRepository : ISyncRepository<InstructorImage, Guid>
{
}
