using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;

namespace Business.Abstracts;

public interface IBootcampStateService
{
    CreateBootcampStateResponse Add(CreateBootcampStateRequest request);
    DeleteBootcampStateResponse Delete(DeleteBootcampStateRequest request);
    UpdateBootcampStateResponse Update(UpdateBootcampStateRequest request);
    GetByIdBootcampStateResponse GetById(int id);
    List<GetAllBootcampStateResponse> GetAll();
}
