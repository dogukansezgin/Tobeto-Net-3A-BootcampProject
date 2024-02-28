using AutoMapper;
using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

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

    public IDataResult<CreateUserResponse> Add(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        _userRepository.Add(user);

        CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
        return new SuccessDataResult<CreateUserResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        User user = _userRepository.Get(x => x.Id == id);
        _userRepository.Delete(user);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllUserResponse>> GetAll()
    {
        List<User> users = _userRepository.GetAll();
        List<GetAllUserResponse> responses = _mapper.Map<List<GetAllUserResponse>>(users);
        return new SuccessDataResult<List<GetAllUserResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdUserResponse> GetById(int id)
    {
        User user = _userRepository.Get(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
        return new SuccessDataResult<GetByIdUserResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateUserResponse> Update(UpdateUserRequest request)
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
        return new SuccessDataResult<UpdateUserResponse>(response, "Updated Succesfully");
    }
}
