using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IApplicantService
{
    IDataResult<CreateApplicantResponse> Add(CreateApplicantRequest request);
    IResult Delete(Guid id);
    IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request);
    IDataResult<GetByIdApplicantResponse> GetById(Guid id);
    IDataResult<List<GetAllApplicantResponse>> GetAll();
    void CheckExistById(Guid id);
}
