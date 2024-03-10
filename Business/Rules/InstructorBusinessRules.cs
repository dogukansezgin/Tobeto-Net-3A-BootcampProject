using Business.Requests.Instructors;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class InstructorBusinessRules : BaseBusinessRules
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorBusinessRules(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public Instructor CheckInstructorUpdate(Instructor instructor, UpdateInstructorRequest request)
    {
        instructor.UserName = request.UserName != "string" || request.UserName != null ? request.UserName : instructor.UserName;
        instructor.FirstName = request.FirstName != "string" || request.FirstName != null ? request.FirstName : instructor.FirstName;
        instructor.LastName = request.LastName != "string" || request.LastName != null ? request.LastName : instructor.LastName;
        instructor.CompanyName = request.CompanyName != "string" || request.CompanyName != null ? request.CompanyName : instructor.CompanyName;
        instructor.NationalIdentity = request.NationalIdentity != "string" || request.NationalIdentity != null ? request.NationalIdentity : instructor.NationalIdentity;
        instructor.Email = request.Email != "string" || request.Email != null ? request.Email : instructor.Email;
        var passwordHash = request.PasswordHash.ToString();
        instructor.PasswordHash = passwordHash != "string" || request.PasswordHash != null ? request.PasswordHash : instructor.PasswordHash;
        var passwordSalt = request.PasswordSalt.ToString();
        instructor.PasswordSalt = passwordSalt != "string" || request.PasswordSalt != null ? request.PasswordSalt : instructor.PasswordSalt;
        //instructor.DateOfBirth eklenecek.

        instructor.UpdatedDate = DateTime.UtcNow;
        return instructor;
    }

    public void CheckIfInstructorIdExist(Guid id)
    {
        var isExist = _instructorRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Instructor is not exists.");
    }

    public void CheckIfInstructorNotExist(Instructor instructor)
    {
        var isExistId = _instructorRepository.Get(x => x.Id == instructor.Id) is not null;
        var isExistUserName = _instructorRepository.Get(x => x.UserName.Trim() == instructor.UserName.Trim()) is not null;
        var isExistNationalId = _instructorRepository.Get(x => x.NationalIdentity.Trim() == instructor.NationalIdentity.Trim()) is not null;
        var isExistEmail = _instructorRepository.Get(x => x.Email.Trim() == instructor.Email.Trim()) is not null;
        if (isExistId || isExistUserName || isExistNationalId || isExistEmail) throw new BusinessException("Instructor already exists.");
    }
}
