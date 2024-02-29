using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;

namespace Business.Abstracts.Users;

public interface IUserService
{
    IDataResult<CreateUserResponse> Add(CreateUserRequest request);
    IResult Delete(int id);
    IDataResult<UpdateUserResponse> Update(UpdateUserRequest request);
    IDataResult<GetByIdUserResponse> GetById(int id);
    IDataResult<List<GetAllUserResponse>> GetAll();
}
