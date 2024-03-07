using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly InstructorBusinessRules _instructorBusinessRules;
    private readonly IMapper _mapper;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules instructorBusinessRules)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _instructorBusinessRules = instructorBusinessRules;
    }

    public IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request)
    {
        Instructor instructor = _mapper.Map<Instructor>(request);
        _instructorBusinessRules.CheckIfInstructorNotExist(instructor);
        _instructorRepository.Add(instructor);

        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
        return new SuccessDataResult<CreateInstructorResponse>(response, InstructorMessages.InstructorAdded);
    }

    public void CheckExistById(Guid id)
    {
        _instructorBusinessRules.CheckIfInstructorIdExist(id);
    }

    public IResult Delete(Guid id)
    {
        _instructorBusinessRules.CheckIfInstructorIdExist(id);
        Instructor instructor = _instructorRepository.Get(x => x.Id == id);
        _instructorRepository.Delete(instructor);
        return new SuccessResult(InstructorMessages.InstructorDeleted);
    }

    public IDataResult<List<GetAllInstructorResponse>> GetAll()
    {
        List<Instructor> instructors = _instructorRepository.GetAll();
        List<GetAllInstructorResponse> responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(responses, InstructorMessages.InstructorListed);
    }

    public IDataResult<GetByIdInstructorResponse> GetById(Guid id)
    {
        _instructorBusinessRules.CheckIfInstructorIdExist(id);
        Instructor instructor = _instructorRepository.Get(x => x.Id == id);
        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
        return new SuccessDataResult<GetByIdInstructorResponse>(response, InstructorMessages.InstructorListed);
    }

    public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request)
    {
        _instructorBusinessRules.CheckIfInstructorIdExist(request.Id);
        Instructor instructor = _instructorRepository.Get(u => u.Id == request.Id);

        _instructorBusinessRules.CheckInstructorUpdate(instructor, request);
        _instructorRepository.Update(instructor);

        UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
        return new SuccessDataResult<UpdateInstructorResponse>(response, InstructorMessages.InstructorUpdated);
    }
}
