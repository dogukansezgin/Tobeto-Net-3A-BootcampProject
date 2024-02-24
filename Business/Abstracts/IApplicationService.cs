using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationService
{
    IDataResult<CreateApplicationResponse> Add(CreateApplicationRequest request);
    IDataResult<DeleteApplicationResponse> Delete(DeleteApplicationRequest request);
    IDataResult<UpdateApplicationResponse> Update(UpdateApplicationRequest request);
    IDataResult<GetByIdApplicationResponse> GetById(int id);
    IDataResult<List<GetAllApplicationResponse>> GetAll();
}
