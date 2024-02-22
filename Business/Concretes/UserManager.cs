using Business.Abstracts;
using Entities.Concretes;
using DataAccess.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using AutoMapper;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public CreateUserResponse Add(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        _userRepository.Add(user);

        CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
        return response;
    }

    public DeleteUserResponse Delete(DeleteUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        _userRepository.Delete(user);

        DeleteUserResponse response = _mapper.Map<DeleteUserResponse>(user);
        return response;
    }

    public List<GetAllUserResponse> GetAll()
    {
        List<User> users = _userRepository.GetAll();
        List<GetAllUserResponse> responses = _mapper.Map<List<GetAllUserResponse>>(users);
        return responses;
    }

    public GetByIdUserResponse GetById(int id)
    {
        User user = _userRepository.Get(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
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

        UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);
        return response;
    }
}
