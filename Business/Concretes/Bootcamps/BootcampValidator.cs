using Business.Abstracts.Bootcamps;
using Business.Requests.Bootcamps;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Bootcamps;

public class BootcampValidator : IBootcampValidator
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IBootcampStateRepository _bootcampStateRepository;

    public BootcampValidator(IBootcampRepository bootcampRepository, IInstructorRepository instructorRepository, IBootcampStateRepository bootcampStateRepository)
    {
        _bootcampRepository = bootcampRepository;
        _instructorRepository = instructorRepository;
        _bootcampStateRepository = bootcampStateRepository;
    }

    public Bootcamp CheckBootcampUpdate(Bootcamp bootcamp, UpdateBootcampRequest request)
    {
        bootcamp.Name = request.Name != "string" || request.Name == null ? request.Name : bootcamp.Name;
        bootcamp.InstructorId = (int)(request.InstructorId != 0 || request.InstructorId == null ? request.InstructorId : bootcamp.InstructorId);
        bootcamp.BootcampStateId = (int)(request.BootcampStateId != 0 || request.BootcampStateId == null ? request.BootcampStateId : bootcamp.BootcampStateId);
        //bootcamp.StartDate ??
        //bootcamp.EndDate ??

        bootcamp.UpdatedDate = DateTime.UtcNow;
        return bootcamp;
    }

    public void CheckForeginKeyIdExist(Bootcamp b)
    {
        var isExistInstructorId = _instructorRepository.Get(x => x.Id == b.InstructorId) is null;
        var isExistBootcampStateId = _bootcampStateRepository.Get(x => x.Id == b.BootcampStateId) is null;
        if (isExistInstructorId || isExistBootcampStateId) throw new BusinessException("Foreign key(s) missing.");
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
