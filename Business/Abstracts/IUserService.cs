using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IUserService
{
    CreateUserResponse Add(CreateUserRequest request);
    DeleteUserResponse Delete(DeleteUserRequest request);
    UpdateUserResponse Update(UpdateUserRequest request);
    GetByIdUserResponse GetById(int id);
    List<GetAllUserResponse> GetAll();
}
