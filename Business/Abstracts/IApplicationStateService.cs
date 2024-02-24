using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationStateService
{
    IDataResult<CreateApplicationStateResponse> Add(CreateApplicationStateRequest request);
    IDataResult<DeleteApplicationStateResponse> Delete(DeleteApplicationStateRequest request);
    IDataResult<UpdateApplicationStateResponse> Update(UpdateApplicationStateRequest request);
    IDataResult<GetByIdApplicationStateResponse> GetById(int id);
    IDataResult<List<GetAllApplicationStateResponse>> GetAll();
}
