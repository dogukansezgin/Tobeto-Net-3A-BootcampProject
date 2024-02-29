using Business.Abstracts.Applicants;
using Business.Requests.Applicants;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Applicants;

public class ApplicantValidator : IApplicantValidator
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantValidator(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public Applicant CheckApplicantUpdate(Applicant applicant, UpdateApplicantRequest request)
    {
        applicant.UserName = request.UserName != "string" || request.UserName == null ? request.UserName : applicant.UserName;
        applicant.FirstName = request.FirstName != "string" || request.FirstName == null ? request.FirstName : applicant.FirstName;
        applicant.LastName = request.LastName != "string" || request.LastName == null ? request.LastName : applicant.LastName;
        applicant.About = request.About != "string" || request.About == null ? request.About : applicant.About;
        applicant.NationalIdentity = request.NationalIdentity != "string" || request.NationalIdentity == null ? request.NationalIdentity : applicant.NationalIdentity;
        applicant.Email = request.Email != "string" || request.Email == null ? request.Email : applicant.Email;
        //applicant.DateOfBirth eklenecek.

        applicant.UpdatedDate = DateTime.UtcNow;
        return applicant;
    }

    public void CheckIfApplicantIdExist(int id)
    {
        var isExist = _applicantRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Applicant is not exists.");
    }

    public void CheckIfApplicantNotExist(Applicant applicant)
    {
        var isExistId = _applicantRepository.Get(x => x.Id == applicant.Id) is not null;
        var isExistUserName = _applicantRepository.Get(x => x.UserName.Trim() == applicant.UserName.Trim()) is not null;
        var isExistNationalId = _applicantRepository.Get(x => x.NationalIdentity.Trim() == applicant.NationalIdentity.Trim()) is not null;
        var isExistEmail = _applicantRepository.Get(x => x.Email.Trim() == applicant.Email.Trim()) is not null;
        if (isExistId || isExistUserName || isExistNationalId || isExistEmail) throw new BusinessException("Applicant already exists.");
    }
}
