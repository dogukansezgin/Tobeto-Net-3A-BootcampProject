using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
    }

    public IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request)
    {
        Instructor instructor = _mapper.Map<Instructor>(request);
        _instructorRepository.Add(instructor);

        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
        return new SuccessDataResult<CreateInstructorResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
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
        Instructor instructor = _instructorRepository.Get(x => x.Id == id);
        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
        return new SuccessDataResult<GetByIdInstructorResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request)
    {
        Instructor instructor = _instructorRepository.Get(u => u.Id == request.Id);
        instructor.UserName = request.UserName ?? instructor.UserName;
        instructor.FirstName = request.FirstName ?? instructor.FirstName;
        instructor.LastName = request.LastName ?? instructor.LastName;
        instructor.CompanyName = request.CompanyName ?? instructor.CompanyName;
        instructor.DateOfBirth = request.DateOfBirth ?? instructor.DateOfBirth;
        instructor.NationalIdentity = request.NationalIdentity ?? instructor.NationalIdentity;
        instructor.Email = request.Email ?? instructor.Email;
        instructor.Password = request.Password ?? instructor.Password;
        instructor.UpdatedDate = DateTime.UtcNow;
        _instructorRepository.Update(instructor);

        UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
        return new SuccessDataResult<UpdateInstructorResponse>(response, "Updated Succesfully");
    }
}
