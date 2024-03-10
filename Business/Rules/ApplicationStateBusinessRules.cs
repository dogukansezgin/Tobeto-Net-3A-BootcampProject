using Business.Requests.ApplicationStates;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicationStateBusinessRules : BaseBusinessRules
{
    private readonly IApplicationStateRepository _applicationStateRepository;

    public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
    {
        _applicationStateRepository = applicationStateRepository;
    }

    public ApplicationState CheckApplicationStateUpdate(ApplicationState applicationState, UpdateApplicationStateRequest request)
    {
        applicationState.Name = request.Name != "string" || request.Name != null ? request.Name : applicationState.Name;

        applicationState.UpdatedDate = DateTime.UtcNow;
        return applicationState;
    }

    public void CheckIfApplicationStateIdExist(int id)
    {
        var isExist = _applicationStateRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("ApplicationState is not exists.");
    }

    public void CheckIfApplicationStateNotExist(ApplicationState applicationState)
    {
        var isExistName = _applicationStateRepository.Get(x => x.Name.Trim() == applicationState.Name.Trim()) is not null;
        if (isExistName) throw new BusinessException("ApplicationState already exists.");
    }
}
