using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Users;
using Business.Responses.Users;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public IDataResult<CreateUserResponse> Add(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        _userBusinessRules.CheckIfUserNotExist(user);
        _userRepository.Add(user);

        CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
        return new SuccessDataResult<CreateUserResponse>(response, UserMessages.UserAdded);
    }

    public IResult Delete(Guid id)
    {
        _userBusinessRules.CheckIfUserIdExist(id);
        User user = _userRepository.Get(x => x.Id == id);
        _userRepository.Delete(user);
        return new SuccessResult(UserMessages.UserDeleted);
    }

    public IDataResult<List<GetAllUserResponse>> GetAll()
    {
        List<User> users = _userRepository.GetAll();
        List<GetAllUserResponse> responses = _mapper.Map<List<GetAllUserResponse>>(users);
        return new SuccessDataResult<List<GetAllUserResponse>>(responses, UserMessages.UserListed);
    }

    public IDataResult<GetByIdUserResponse> GetById(Guid id)
    {
        _userBusinessRules.CheckIfUserIdExist(id);
        User user = _userRepository.Get(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
        return new SuccessDataResult<GetByIdUserResponse>(response, UserMessages.UserListed);
    }

    public IDataResult<UpdateUserResponse> Update(UpdateUserRequest request)
    {
        _userBusinessRules.CheckIfUserIdExist(request.Id);
        User user = _userRepository.Get(u => u.Id == request.Id);

        _userBusinessRules.CheckUserUpdate(user, request);
        _userRepository.Update(user);

        UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);
        return new SuccessDataResult<UpdateUserResponse>(response, UserMessages.UserUpdated);
    }
}
