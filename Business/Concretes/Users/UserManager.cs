using AutoMapper;
using Business.Abstracts.Users;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Users;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper, IUserValidator userValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userValidator = userValidator;
    }

    public IDataResult<CreateUserResponse> Add(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        _userValidator.CheckIfUserNotExist(user);
        _userRepository.Add(user);

        CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
        return new SuccessDataResult<CreateUserResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _userValidator.CheckIfUserIdExist(id);
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
        _userValidator.CheckIfUserIdExist(id);
        User user = _userRepository.Get(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
        return new SuccessDataResult<GetByIdUserResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateUserResponse> Update(UpdateUserRequest request)
    {
        _userValidator.CheckIfUserIdExist(request.Id);
        User user = _userRepository.Get(u => u.Id == request.Id);
        
        _userValidator.CheckUserUpdate(user, request);
        _userRepository.Update(user);

        UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);
        return new SuccessDataResult<UpdateUserResponse>(response, "Updated Succesfully");
    }
}
