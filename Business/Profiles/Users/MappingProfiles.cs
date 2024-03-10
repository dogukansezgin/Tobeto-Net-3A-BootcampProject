using AutoMapper;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;

namespace Business.Profiles.Users;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, UpdateUserRequest>().ReverseMap();
        CreateMap<User, CreateUserResponse>().ReverseMap();
        CreateMap<User, DeleteUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserResponse>().ReverseMap();
        CreateMap<User, GetAllUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
    }
}
