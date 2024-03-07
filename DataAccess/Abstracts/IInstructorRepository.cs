using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IInstructorRepository : ISyncRepository<Instructor, Guid>
{
}
