using Business.Abstracts;
using Business.Requests.Applications;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IApplicantService _applicantService;
    private readonly IBootcampService _bootcampService;
    private readonly IApplicationStateService _applicationStateService;
    private readonly IBlacklistService _blacklistService;

    public ApplicationBusinessRules(IApplicationRepository applicationRepository, IApplicantService applicantService, IBootcampService bootcampService, IApplicationStateService applicationStateService, IBlacklistService blacklistService)
    {
        _applicationRepository = applicationRepository;
        _applicantService = applicantService;
        _bootcampService = bootcampService;
        _applicationStateService = applicationStateService;
        _blacklistService = blacklistService;
    }

    public Application CheckApplicationUpdate(Application application, UpdateApplicationRequest request)
    {
        application.ApplicantId = request.ApplicantId == null ? request.ApplicantId : application.ApplicantId;
        application.BootcampId = request.BootcampId != 0 || request.BootcampId == null ? request.BootcampId : application.BootcampId;
        application.ApplicationStateId = request.ApplicationStateId != 0 || request.ApplicationStateId == null ? request.ApplicationStateId : application.ApplicationStateId;

        application.UpdatedDate = DateTime.UtcNow;
        return application;
    }

    public void CheckForeginKeyIdExist(Application application)
    {
        _applicantService.CheckExistById(application.ApplicantId);
        _bootcampService.CheckExistById(application.BootcampId);
        _applicationStateService.CheckExistById(application.ApplicationStateId);
    }

    public void CheckIfApplicationIdExist(int id)
    {
        var isExist = _applicationRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Application is not exists.");
    }

    public void CheckIfApplicationNotExist(Application application)
    {
        var isExistApplicantId = _applicationRepository.Get(x => x.ApplicantId == application.ApplicantId) is not null;
        var isExistBootcampId = _applicationRepository.Get(x => x.BootcampId == application.BootcampId) is not null;

        CheckForeginKeyIdExist(application);
        _blacklistService.CheckIfApplicantBlacklisted(application.ApplicantId);

        if (isExistApplicantId && isExistBootcampId) throw new BusinessException("Application already exists.");
    }
}
