using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.Repositories;

public class BootcampImageRepository : EfRepositoryBase<BootcampImage, Guid, BaseDbContext>, IBootcampImageRepository
{
    public BootcampImageRepository(BaseDbContext context) : base(context)
    {

    }
}
