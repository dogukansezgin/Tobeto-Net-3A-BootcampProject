using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IUserService
{
    IDataResult<CreateUserResponse> Add(CreateUserRequest request);
    IDataResult<DeleteUserResponse> Delete(DeleteUserRequest request);
    IDataResult<UpdateUserResponse> Update(UpdateUserRequest request);
    IDataResult<GetByIdUserResponse> GetById(int id);
    IDataResult<List<GetAllUserResponse>> GetAll();
}
