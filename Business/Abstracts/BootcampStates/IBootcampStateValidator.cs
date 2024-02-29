using Business.Requests.BootcampStates;
using Entities.Concretes;

namespace Business.Abstracts.BootcampStates;

public interface IBootcampStateValidator
{
    void CheckIfBootcampStateNotExist(BootcampState bootcampState);
    void CheckIfBootcampStateIdExist(int id);
    BootcampState CheckBootcampStateUpdate(BootcampState bootcampState, UpdateBootcampStateRequest request);
}
