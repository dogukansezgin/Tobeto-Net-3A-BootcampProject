﻿using AutoMapper;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Entities.Concretes;

namespace Business.Profiles.Applicants;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, CreateApplicantResponse>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantResponse>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();
    }
}

