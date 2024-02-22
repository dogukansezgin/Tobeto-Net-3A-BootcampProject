using AutoMapper;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Entities.Concretes;

namespace Business.Profiles.BootcampStates;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BootcampState, CreateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, CreateBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();
    }
}
