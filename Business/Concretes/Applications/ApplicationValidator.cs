using Business.Abstracts.Applications;
using Business.Requests.Applications;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Applications;

public class ApplicationValidator : IApplicationValidator
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly IBlacklistRepository _blacklistRepository;

    public ApplicationValidator(IApplicationRepository applicationRepository, IApplicantRepository applicantRepository, IBootcampRepository bootcampRepository, IApplicationStateRepository applicationStateRepository, IBlacklistRepository blacklistRepository)
    {
        _applicationRepository = applicationRepository;
        _applicantRepository = applicantRepository;
        _bootcampRepository = bootcampRepository;
        _applicationStateRepository = applicationStateRepository;
        _blacklistRepository = blacklistRepository;
    }

    public Application CheckApplicationUpdate(Application application, UpdateApplicationRequest request)
    {
        application.ApplicantId = request.ApplicantId != 0 || request.ApplicantId == null ? request.ApplicantId : application.ApplicantId;
        application.BootcampId = request.BootcampId != 0 || request.BootcampId == null ? request.BootcampId : application.BootcampId;
        application.ApplicationStateId = request.ApplicationStateId != 0 || request.ApplicationStateId == null ? request.ApplicationStateId : application.ApplicationStateId;

        application.UpdatedDate = DateTime.UtcNow;
        return application;
    }

    public void CheckForeginKeyIdExist(Application application)
    {
        var isExistApplicantId = _applicantRepository.Get(x => x.Id == application.ApplicantId) is null;
        var isExistBootcampId = _bootcampRepository.Get(x => x.Id == application.BootcampId) is null;
        var isExistApplicationStateId = _applicationStateRepository.Get(x => x.Id == application.ApplicationStateId) is null;
        if (isExistApplicantId || isExistBootcampId || isExistApplicationStateId) throw new BusinessException("Foreign key(s) missing.");
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
        CheckIsInBlacklist(application.ApplicantId);
        if (isExistApplicantId && isExistBootcampId) throw new BusinessException("Application already exists.");
    }

    public void CheckIsInBlacklist(int applicantId)
    {
        var isInBlacklist = _blacklistRepository.Get(x => x.ApplicantId == applicantId) is not null;
        if (isInBlacklist) throw new BusinessException("Applicant is blacklisted.");
    }
}
