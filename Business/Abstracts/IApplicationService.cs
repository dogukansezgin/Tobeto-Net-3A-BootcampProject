using Business.Requests.Applications;
using Business.Responses.Applications;

namespace Business.Abstracts;

public interface IApplicationService
{
    CreateApplicationResponse Add(CreateApplicationRequest request);
    DeleteApplicationResponse Delete(DeleteApplicationRequest request);
    UpdateApplicationResponse Update(UpdateApplicationRequest request);
    GetByIdApplicationResponse GetById(int id);
    List<GetAllApplicationResponse> GetAll();
}
