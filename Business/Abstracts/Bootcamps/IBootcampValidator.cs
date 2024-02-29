using Business.Requests.Bootcamps;
using Entities.Concretes;

namespace Business.Abstracts.Bootcamps;

public interface IBootcampValidator
{
    void CheckIfBootcampNotExist(Bootcamp bootcamp);
    void CheckIfBootcampIdExist(int id);
    void CheckForeginKeyIdExist(Bootcamp bootcamp);
    Bootcamp CheckBootcampUpdate(Bootcamp bootcamp, UpdateBootcampRequest request);
}
