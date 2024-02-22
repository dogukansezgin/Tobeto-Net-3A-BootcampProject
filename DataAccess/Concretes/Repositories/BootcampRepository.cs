using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.Repositories;

public class BootcampRepository : EfRepositoryBase<Bootcamp, int, BaseDbContext>, IBootcampRepository
{
    public BootcampRepository(BaseDbContext context) : base(context)
    {

    }
}
