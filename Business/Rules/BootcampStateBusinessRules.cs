using Business.Requests.BootcampStates;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class BootcampStateBusinessRules : BaseBusinessRules
{
    private readonly IBootcampStateRepository _bootcampStateRepository;

    public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
    {
        _bootcampStateRepository = bootcampStateRepository;
    }

    public BootcampState CheckBootcampStateUpdate(BootcampState bootcampState, UpdateBootcampStateRequest request)
    {
        bootcampState.Name = request.Name != "string" || request.Name != null ? request.Name : bootcampState.Name;

        bootcampState.UpdatedDate = DateTime.UtcNow;
        return bootcampState;
    }

    public void CheckIfBootcampStateIdExist(int id)
    {
        var isExist = _bootcampStateRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("BootcampState is not exists.");
    }

    public void CheckIfBootcampStateNotExist(BootcampState bootcampState)
    {
        var isExistName = _bootcampStateRepository.Get(x => x.Name.Trim() == bootcampState.Name.Trim()) is not null;
        if (isExistName) throw new BusinessException("BootcampState already exists.");
    }
}
