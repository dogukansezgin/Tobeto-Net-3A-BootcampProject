﻿using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using Entities.Concretes;
using Business.Abstracts;
using AutoMapper;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
    }

    public CreateApplicantResponse Add(CreateApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        _applicantRepository.Add(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return response;
    }

    public DeleteApplicantResponse Delete(DeleteApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        _applicantRepository.Delete(applicant);

        DeleteApplicantResponse response = _mapper.Map<DeleteApplicantResponse>(applicant);
        return response;
    }

    public List<GetAllApplicantResponse> GetAll()
    {
        List<Applicant> applicants = _applicantRepository.GetAll();
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);
        return responses;
    }

    public GetByIdApplicantResponse GetById(int id)
    {
        Applicant applicant = _applicantRepository.Get(x => x.Id == id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return response;
    }

    public UpdateApplicantResponse Update(UpdateApplicantRequest request)
    {
        Applicant applicant = _applicantRepository.Get(u => u.Id == request.Id);
        applicant.UserName = request.UserName ?? applicant.UserName;
        applicant.FirstName = request.FirstName ?? applicant.FirstName;
        applicant.LastName = request.LastName ?? applicant.LastName;
        applicant.About = request.About ?? applicant.About;
        applicant.DateOfBirth = request.DateOfBirth ?? applicant.DateOfBirth;
        applicant.NationalIdentity = request.NationalIdentity ?? applicant.NationalIdentity;
        applicant.Email = request.Email ?? applicant.Email;
        applicant.Password = request.Password ?? applicant.Password;
        applicant.UpdatedDate = DateTime.UtcNow;
        _applicantRepository.Update(applicant);

        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return response;
    }
}