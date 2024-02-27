using AutoMapper;
using Business.Requests.BootcampImages;
using Business.Responses.BootcampImages;
using Entities.Concretes;

namespace Business.Profiles.BootcampImages;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BootcampImage, CreateBootcampImageRequest>().ReverseMap();
        CreateMap<BootcampImage, DeleteBootcampImageRequest>().ReverseMap();
        CreateMap<BootcampImage, UpdateBootcampImageRequest>().ReverseMap();
        CreateMap<BootcampImage, CreateBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, DeleteBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, UpdateBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, GetAllBootcampImageResponse>().ReverseMap();
        CreateMap<BootcampImage, GetByIdBootcampImageResponse>().ReverseMap();
    }
}
