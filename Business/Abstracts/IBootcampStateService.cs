using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampStateService
{
    IDataResult<CreateBootcampStateResponse> Add(CreateBootcampStateRequest request);
    IResult Delete(int id);
    IDataResult<UpdateBootcampStateResponse> Update(UpdateBootcampStateRequest request);
    IDataResult<GetByIdBootcampStateResponse> GetById(int id);
    IDataResult<List<GetAllBootcampStateResponse>> GetAll();
    void CheckExistById(int id);

}
