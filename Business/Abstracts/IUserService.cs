using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IUserService
{
    IDataResult<CreateUserResponse> Add(CreateUserRequest request);
    IResult Delete(Guid id);
    IDataResult<UpdateUserResponse> Update(UpdateUserRequest request);
    IDataResult<GetByIdUserResponse> GetById(Guid id);
    IDataResult<List<GetAllUserResponse>> GetAll();
}
