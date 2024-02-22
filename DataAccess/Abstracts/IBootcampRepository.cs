using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBootcampRepository : ISyncRepository<Bootcamp, int>
{
}
