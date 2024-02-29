using Business.Requests.Users;
using Entities.Concretes;

namespace Business.Abstracts.Users;

public interface IUserValidator
{
    void CheckIfUserNotExist(User user);
    void CheckIfUserIdExist(int id);
    User CheckUserUpdate(User user, UpdateUserRequest request);
}
