using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ApplicantManager
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantManager(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public CreateApplicantResponse Add(CreateApplicantRequest request)
    {
        Applicant applicant = new Applicant();
        applicant.UserName = request.UserName;
        applicant.FirstName = request.FirstName;
        applicant.LastName = request.LastName;
        applicant.About = request.About;
        applicant.DateOfBirth = request.DateOfBirth;
        applicant.NationalIdentity = request.NationalIdentity;
        applicant.Email = request.Email;
        applicant.Password = request.Password;
        _applicantRepository.Add(applicant);

        CreateApplicantResponse response = new CreateApplicantResponse();
        response.Id = applicant.Id;
        response.UserName = applicant.UserName;
        response.About = applicant.About;
        response.CreatedDate = applicant.CreatedDate;
        return response;
    }

    public DeleteApplicantResponse Delete(DeleteApplicantRequest request)
    {
        Applicant applicant = new Applicant()
        { Id = request.Id, UserName = request.UserName };
        _applicantRepository.Delete(applicant);

        DeleteApplicantResponse response = new DeleteApplicantResponse();
        response.Id = applicant.Id;
        response.UserName = applicant.UserName;
        return response;
    }

    public List<GetAllApplicantResponse> GetAll()
    {
        List<GetAllApplicantResponse> applicants = new();

        foreach (var applicant in _applicantRepository.GetAll())
        {
            GetAllApplicantResponse response = new();
            response.Id = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.About = applicant.About;
            response.DateOfBirth = applicant.DateOfBirth;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Email = applicant.Email;
            response.Password = applicant.Password;
            response.CreatedDate = applicant.CreatedDate;
            response.DeletedDate = applicant.DeletedDate;
            response.UpdatedDate = applicant.UpdatedDate;
            applicants.Add(response);
        }
        return applicants;
    }

    public GetByIdApplicantResponse GetById(int id)
    {
        GetByIdApplicantResponse response = new();
        Applicant applicant = _applicantRepository.Get(x => x.Id == id);
        response.Id = applicant.Id;
        response.UserName = applicant.UserName;
        response.FirstName = applicant.FirstName;
        response.LastName = applicant.LastName;
        response.About = applicant.About;
        response.DateOfBirth = applicant.DateOfBirth;
        response.NationalIdentity = applicant.NationalIdentity;
        response.Email = applicant.Email;
        response.Password = applicant.Password;
        response.CreatedDate = applicant.CreatedDate;
        response.DeletedDate = applicant.DeletedDate;
        response.UpdatedDate = applicant.UpdatedDate;
        return response;
    }

    public UpdateApplicantResponse Update(UpdateApplicantRequest request)
    {
        Applicant applicant = _applicantRepository.Get(u => u.Id == request.Id);
        applicant.UserName = request.UserName ?? applicant.UserName;
        applicant.FirstName = request.FirstName ?? applicant.FirstName;
        applicant.LastName = request.LastName ?? applicant.LastName;
        applicant.About = request.About ?? applicant.About;
        applicant.DateOfBirth = request.DateOfBirth ?? applicant.DateOfBirth;
        applicant.NationalIdentity = request.NationalIdentity ?? applicant.NationalIdentity;
        applicant.Email = request.Email ?? applicant.Email;
        applicant.Password = request.Password ?? applicant.Password;
        applicant.UpdatedDate = DateTime.UtcNow;
        _applicantRepository.Update(applicant);

        UpdateApplicantResponse response = new();
        response.UserName = applicant.UserName;
        response.FirstName = applicant.FirstName;
        response.LastName = applicant.LastName;
        response.About = applicant.About;
        response.DateOfBirth = applicant.DateOfBirth;
        response.NationalIdentity = applicant.NationalIdentity;
        response.Email = applicant.Email;
        response.Password = applicant.Password;
        response.UpdatedDate = (DateTime)applicant.UpdatedDate;
        return response;
    }
}
