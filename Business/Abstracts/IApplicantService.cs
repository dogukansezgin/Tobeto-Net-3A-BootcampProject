using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicantService
{
    IDataResult<CreateApplicantResponse> Add(CreateApplicantRequest request);
    IDataResult<DeleteApplicantResponse> Delete(DeleteApplicantRequest request);
    IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request);
    IDataResult<GetByIdApplicantResponse> GetById(int id);
    IDataResult<List<GetAllApplicantResponse>> GetAll();
}
