using Business.Requests.ApplicationStates;
using Entities.Concretes;

namespace Business.Abstracts.ApplicatonStates;

public interface IApplicationStateValidator
{
    void CheckIfApplicationStateNotExist(ApplicationState applicationState);
    void CheckIfApplicationStateIdExist(int id);
    ApplicationState CheckApplicationStateUpdate(ApplicationState applicationState, UpdateApplicationStateRequest request);
}
