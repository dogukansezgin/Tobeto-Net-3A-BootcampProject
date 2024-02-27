using AutoMapper;
using Business.Requests.InstructorImages;
using Business.Responses.InstructorImages;
using Entities.Concretes;

namespace Business.Profiles.InstructorImages;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<InstructorImage, CreateInstructorImageRequest>().ReverseMap();
        CreateMap<InstructorImage, DeleteInstructorImageRequest>().ReverseMap();
        CreateMap<InstructorImage, UpdateInstructorImageRequest>().ReverseMap();
        CreateMap<InstructorImage, CreateInstructorImageResponse>().ReverseMap();
        CreateMap<InstructorImage, DeleteInstructorImageResponse>().ReverseMap();
        CreateMap<InstructorImage, UpdateInstructorImageResponse>().ReverseMap();
        CreateMap<InstructorImage, GetAllInstructorImageResponse>().ReverseMap();
        CreateMap<InstructorImage, GetByIdInstructorImageResponse>().ReverseMap();
    }
}
