using Business.Abstracts.ApplicatonStates;
using Business.Requests.ApplicationStates;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concretes.ApplicationStates;

public class ApplicationStateValidator : IApplicationStateValidator
{
    private readonly IApplicationStateRepository _applicationStateRepository;

    public ApplicationStateValidator(IApplicationStateRepository applicationStateRepository)
    {
        _applicationStateRepository = applicationStateRepository;
    }

    public ApplicationState CheckApplicationStateUpdate(ApplicationState applicationState, UpdateApplicationStateRequest request)
    {
        applicationState.Name = request.Name != "string" || request.Name == null ? request.Name : applicationState.Name;

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
