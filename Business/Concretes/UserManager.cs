using Business.Abstracts;
using Entities.Concretes;
using DataAccess.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public CreateUserResponse Add(CreateUserRequest request)
    {
        User user = new User();
        user.UserName = request.UserName;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.DateOfBirth = request.DateOfBirth;
        user.NationalIdentity = request.NationalIdentity;
        user.Email = request.Email;
        user.Password = request.Password;
        _userRepository.Add(user);

        CreateUserResponse response = new CreateUserResponse();
        response.Id = user.Id;
        response.UserName = user.UserName;
        response.Email = user.Email;
        response.CreatedDate = user.CreatedDate;
        return response;
    }

    public DeleteUserResponse Delete(DeleteUserRequest request)
    {
        User user = new User() 
        { Id = request.Id, UserName = request.UserName};
        _userRepository.Delete(user);

        DeleteUserResponse response = new DeleteUserResponse();
        response.Id = user.Id;
        response.UserName = user.UserName;
        return response;
    }

    public List<GetAllUserResponse> GetAll()
    {
        List<GetAllUserResponse> users = new();

        foreach (var user in _userRepository.GetAll())
        {
            GetAllUserResponse response = new();
            response.Id = user.Id;
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            response.Email = user.Email;
            response.Password = user.Password;
            response.CreatedDate = user.CreatedDate;
            response.DeletedDate = user.DeletedDate;
            response.UpdatedDate = user.UpdatedDate;
            users.Add(response);
        }
        return users;
    }

    public GetByIdUserResponse GetById(int id)
    {
        GetByIdUserResponse response = new();
        User user = _userRepository.Get(x => x.Id == id);
        response.Id = user.Id;
        response.UserName = user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.DateOfBirth = user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        response.Email = user.Email;
        response.Password = user.Password;
        response.CreatedDate = user.CreatedDate;
        response.DeletedDate = user.DeletedDate;
        response.UpdatedDate = user.UpdatedDate;
        return response;
    }

    public UpdateUserResponse Update(UpdateUserRequest request)
    {
        User user = _userRepository.Get(u => u.Id == request.Id);
        user.UserName = request.UserName ?? user.UserName;
        user.FirstName = request.FirstName ?? user.FirstName;
        user.LastName = request.LastName ?? user.LastName;
        user.DateOfBirth = request.DateOfBirth ?? user.DateOfBirth;
        user.NationalIdentity = request.NationalIdentity ?? user.NationalIdentity;
        user.Email = request.Email ?? user.Email;
        user.Password = request.Password ?? user.Password;
        user.UpdatedDate = DateTime.UtcNow;
        _userRepository.Update(user);

        UpdateUserResponse response = new();
        response.UserName = user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.DateOfBirth = user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        response.Email = user.Email;
        response.Password = user.Password;
        response.UpdatedDate = (DateTime)user.UpdatedDate;
        return response;
    }
}
