using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;

namespace Business.Abstracts.ApplicatonStates;

public interface IApplicationStateService
{
    IDataResult<CreateApplicationStateResponse> Add(CreateApplicationStateRequest request);
    IResult Delete(int id);
    IDataResult<UpdateApplicationStateResponse> Update(UpdateApplicationStateRequest request);
    IDataResult<GetByIdApplicationStateResponse> GetById(int id);
    IDataResult<List<GetAllApplicationStateResponse>> GetAll();
}
