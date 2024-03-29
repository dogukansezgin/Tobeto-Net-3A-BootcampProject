﻿using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly ApplicationBusinessRules _applicationBusinessRules;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, ApplicationBusinessRules applicationBusinessRules, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _applicationBusinessRules = applicationBusinessRules;
        _mapper = mapper;
    }

    public IDataResult<CreateApplicationResponse> Add(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        _applicationBusinessRules.CheckIfApplicationNotExist(application);
        _applicationRepository.Add(application);

        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return new SuccessDataResult<CreateApplicationResponse>(response, ApplicationMessages.ApplicationAdded);
    }

    public IResult Delete(int id)
    {
        _applicationBusinessRules.CheckIfApplicationIdExist(id);
        Application application = _applicationRepository.Get(x => x.Id == id);
        _applicationRepository.Delete(application);
        return new SuccessResult(ApplicationMessages.ApplicationDeleted);
    }

    public IDataResult<List<GetAllApplicationResponse>> GetAll()
    {
        List<Application> applications = _applicationRepository.GetAll(include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, ApplicationMessages.ApplicationListed);
    }

    public IDataResult<GetByIdApplicationResponse> GetById(int id)
    {
        _applicationBusinessRules.CheckIfApplicationIdExist(id);
        Application application = _applicationRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
        return new SuccessDataResult<GetByIdApplicationResponse>(response, ApplicationMessages.ApplicationListed);
    }

    public IDataResult<UpdateApplicationResponse> Update(UpdateApplicationRequest request)
    {
        _applicationBusinessRules.CheckIfApplicationIdExist(request.Id);
        Application application = _applicationRepository.Get(x => x.Id == request.Id);

        application = _applicationBusinessRules.CheckApplicationUpdate(application, request);
        _applicationRepository.Update(application);

        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
        return new SuccessDataResult<UpdateApplicationResponse>(response, ApplicationMessages.ApplicationUpdated);
    }
}
