using AutoMapper;
using Business.Abstracts.Instructors;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Instructors;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IInstructorValidator _instructorValidator;
    private readonly IMapper _mapper;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, IInstructorValidator instructorValidator)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _instructorValidator = instructorValidator;
    }

    public IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request)
    {
        Instructor instructor = _mapper.Map<Instructor>(request);
        _instructorValidator.CheckIfInstructorNotExist(instructor);
        _instructorRepository.Add(instructor);

        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
        return new SuccessDataResult<CreateInstructorResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _instructorValidator.CheckIfInstructorIdExist(id);
        Instructor instructor = _instructorRepository.Get(x => x.Id == id);
        _instructorRepository.Delete(instructor);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllInstructorResponse>> GetAll()
    {
        List<Instructor> instructors = _instructorRepository.GetAll();
        List<GetAllInstructorResponse> responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdInstructorResponse> GetById(int id)
    {
        _instructorValidator.CheckIfInstructorIdExist(id);
        Instructor instructor = _instructorRepository.Get(x => x.Id == id);
        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
        return new SuccessDataResult<GetByIdInstructorResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request)
    {
        _instructorValidator.CheckIfInstructorIdExist(request.Id);
        Instructor instructor = _instructorRepository.Get(u => u.Id == request.Id);
        
        _instructorValidator.CheckInstructorUpdate(instructor, request);
        _instructorRepository.Update(instructor);

        UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
        return new SuccessDataResult<UpdateInstructorResponse>(response, "Updated Succesfully");
    }
}
