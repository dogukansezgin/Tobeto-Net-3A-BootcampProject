using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;

namespace Business.Abstracts;

public interface IBootcampService
{
    CreateBootcampResponse Add(CreateBootcampRequest request);
    DeleteBootcampResponse Delete(DeleteBootcampRequest request);
    UpdateBootcampResponse Update(UpdateBootcampRequest request);
    GetByIdBootcampResponse GetById(int id);
    List<GetAllBootcampResponse> GetAll();
}
