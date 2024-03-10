using Business.Abstracts;
using Business.Requests.Bootcamps;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class BootcampBusinessRules : BaseBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IInstructorService _instructorService;
    private readonly IBootcampStateService _bootcampStateService;

    public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorService instructorService, IBootcampStateService bootcampStateService)
    {
        _bootcampRepository = bootcampRepository;
        _instructorService = instructorService;
        _bootcampStateService = bootcampStateService;
    }

    public Bootcamp CheckBootcampUpdate(Bootcamp bootcamp, UpdateBootcampRequest request)
    {
        bootcamp.Name = request.Name != "string" || request.Name != null ? request.Name : bootcamp.Name;
        var instructorId = request.InstructorId.ToString();
        bootcamp.InstructorId = (Guid)(instructorId != "string" || request.InstructorId != null ? request.InstructorId : bootcamp.InstructorId);
        bootcamp.BootcampStateId = (int)(request.BootcampStateId != 0 || request.BootcampStateId != null ? request.BootcampStateId : bootcamp.BootcampStateId);
        //bootcamp.StartDate ??
        //bootcamp.EndDate ??

        bootcamp.UpdatedDate = DateTime.UtcNow;
        return bootcamp;
    }

    public void CheckForeginKeyIdExist(Bootcamp b)
    {
        _instructorService.CheckExistById(b.InstructorId);
        _bootcampStateService.CheckExistById(b.BootcampStateId);
    }

    public void CheckIfBootcampIdExist(int id)
    {
        var isExist = _bootcampRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Bootcamp is not exists.");
    }

    public void CheckIfBootcampNotExist(Bootcamp bootcamp)
    {
        var isExistName = _bootcampRepository.Get(x => x.Name.Trim() == bootcamp.Name.Trim()) is not null;
        CheckForeginKeyIdExist(bootcamp);
        if (isExistName) throw new BusinessException("Bootcamp already exists.");
    }
}
