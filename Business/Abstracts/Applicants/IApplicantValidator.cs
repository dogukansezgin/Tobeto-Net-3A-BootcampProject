using Business.Requests.Applicants;
using Entities.Concretes;

namespace Business.Abstracts.Applicants;

public interface IApplicantValidator
{
    void CheckIfApplicantNotExist(Applicant applicant);
    void CheckIfApplicantIdExist(int id);
    Applicant CheckApplicantUpdate(Applicant applicant, UpdateApplicantRequest request);
}
