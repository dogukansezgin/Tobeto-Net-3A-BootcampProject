using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.Repositories;

public class InstructorImageRepository : EfRepositoryBase<InstructorImage, Guid, BaseDbContext>, IInstructorImageRepository
{
    public InstructorImageRepository(BaseDbContext context) : base(context)
    {

    }
}
