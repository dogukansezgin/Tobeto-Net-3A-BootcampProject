using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorManager(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public CreateInstructorResponse Add(CreateInstructorRequest request)
    {
        Instructor instructor = new Instructor();
        instructor.UserName = request.UserName;
        instructor.FirstName = request.FirstName;
        instructor.LastName = request.LastName;
        instructor.CompanyName = request.CompanyName;
        instructor.DateOfBirth = request.DateOfBirth;
        instructor.NationalIdentity = request.NationalIdentity;
        instructor.Email = request.Email;
        instructor.Password = request.Password;
        _instructorRepository.Add(instructor);

        CreateInstructorResponse response = new CreateInstructorResponse();
        response.Id = instructor.Id;
        response.UserName = instructor.UserName;
        response.CompanyName = instructor.CompanyName;
        response.CreatedDate = instructor.CreatedDate;
        return response;
    }

    public DeleteInstructorResponse Delete(DeleteInstructorRequest request)
    {
        Instructor instructor = new Instructor()
        { Id = request.Id, UserName = request.UserName };
        _instructorRepository.Delete(instructor);

        DeleteInstructorResponse response = new DeleteInstructorResponse();
        response.Id = instructor.Id;
        response.UserName = instructor.UserName;
        return response;
    }

    public List<GetAllInstructorResponse> GetAll()
    {
        List<GetAllInstructorResponse> instructors = new();

        foreach (var instructor in _instructorRepository.GetAll())
        {
            GetAllInstructorResponse response = new();
            response.Id = instructor.Id;
            response.UserName = instructor.UserName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.CompanyName = instructor.CompanyName;
            response.DateOfBirth = instructor.DateOfBirth;
            response.NationalIdentity = instructor.NationalIdentity;
            response.Email = instructor.Email;
            response.Password = instructor.Password;
            response.CreatedDate = instructor.CreatedDate;
            response.DeletedDate = instructor.DeletedDate;
            response.UpdatedDate = instructor.UpdatedDate;
            instructors.Add(response);
        }
        return instructors;
    }

    public GetByIdInstructorResponse GetById(int id)
    {
        GetByIdInstructorResponse response = new();
        Instructor instructor = _instructorRepository.Get(x => x.Id == id);
        response.Id = instructor.Id;
        response.UserName = instructor.UserName;
        response.FirstName = instructor.FirstName;
        response.LastName = instructor.LastName;
        response.CompanyName = instructor.CompanyName;
        response.DateOfBirth = instructor.DateOfBirth;
        response.NationalIdentity = instructor.NationalIdentity;
        response.Email = instructor.Email;
        response.Password = instructor.Password;
        response.CreatedDate = instructor.CreatedDate;
        response.DeletedDate = instructor.DeletedDate;
        response.UpdatedDate = instructor.UpdatedDate;
        return response;
    }

    public UpdateInstructorResponse Update(UpdateInstructorRequest request)
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

        UpdateInstructorResponse response = new();
        response.UserName = instructor.UserName;
        response.FirstName = instructor.FirstName;
        response.LastName = instructor.LastName;
        response.CompanyName = instructor.CompanyName;
        response.DateOfBirth = instructor.DateOfBirth;
        response.NationalIdentity = instructor.NationalIdentity;
        response.Email = instructor.Email;
        response.Password = instructor.Password;
        response.UpdatedDate = (DateTime)instructor.UpdatedDate;
        return response;
    }
}
