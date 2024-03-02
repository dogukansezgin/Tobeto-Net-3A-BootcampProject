using Business.Abstracts;
using Business.Requests.Blacklists;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class BlacklistBusinessRules : BaseBusinessRules
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IApplicantService _applicantService;

    public BlacklistBusinessRules(IBlacklistRepository blacklistRepository, IApplicantService applicantService)
    {
        _blacklistRepository = blacklistRepository;
        _applicantService = applicantService;
    }

    public Blacklist CheckBlacklistUpdate(Blacklist blacklist, UpdateBlacklistRequest request)
    {
        blacklist.ApplicantId = (int)(request.ApplicantId != 0 || request.ApplicantId == null ? request.ApplicantId : blacklist.ApplicantId);
        blacklist.Reason = request.Reason != "string" || request.Reason == null ? request.Reason : blacklist.Reason;
        //blacklist.Date ??

        blacklist.UpdatedDate = DateTime.UtcNow;
        return blacklist;
    }

    public void CheckForeginKeyIdExist(Blacklist blacklist)
    {
        _applicantService.CheckExistById(blacklist.ApplicantId);
    }

    public void CheckIfBlacklistIdExist(int id)
    {
        var isExist = _blacklistRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Blacklist is not exists.");
    }

    public void CheckIfApplicantBlacklisted(int applicantId)
    {
        var isInBlacklist = _blacklistRepository.Get(x => x.ApplicantId == applicantId) is not null;
        if (isInBlacklist) throw new BusinessException("Applicant is blacklisted.");
    }

    public void CheckIfBlacklistNotExist(Blacklist blacklist)
    {
        var isExistApplicantId = _blacklistRepository.Get(x => x.ApplicantId == blacklist.ApplicantId) is not null;
        CheckForeginKeyIdExist(blacklist);
        if (isExistApplicantId) throw new BusinessException("Blacklist already exists.");
    }
}
