using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;

namespace Business.Abstracts.Applicants;

public interface IApplicantService
{
    IDataResult<CreateApplicantResponse> Add(CreateApplicantRequest request);
    IResult Delete(int id);
    IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request);
    IDataResult<GetByIdApplicantResponse> GetById(int id);
    IDataResult<List<GetAllApplicantResponse>> GetAll();
}
