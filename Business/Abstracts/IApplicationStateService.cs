using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;

namespace Business.Abstracts;

public interface IApplicationStateService
{
    CreateApplicationStateResponse Add(CreateApplicationStateRequest request);
    DeleteApplicationStateResponse Delete(DeleteApplicationStateRequest request);
    UpdateApplicationStateResponse Update(UpdateApplicationStateRequest request);
    GetByIdApplicationStateResponse GetById(int id);
    List<GetAllApplicationStateResponse> GetAll();
}
