using Business.Abstracts.Blacklists;
using Business.Requests.Blacklists;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

namespace Business.Concretes.Blacklists;

public class BlacklistValidator : IBlacklistValidator
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IApplicantRepository _applicantRepository;

    public BlacklistValidator(IBlacklistRepository blacklistRepository, IApplicantRepository applicantRepository)
    {
        _blacklistRepository = blacklistRepository;
        _applicantRepository = applicantRepository;
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
        var isExistApplicantId = _applicantRepository.Get(x => x.Id == blacklist.ApplicantId) is null;
        if (isExistApplicantId) throw new BusinessException("Foreign key(s) missing.");
    }

    public void CheckIfBlacklistIdExist(int id)
    {
        var isExist = _blacklistRepository.Get(x => x.Id == id) is null;
        if (isExist) throw new BusinessException("Blacklist is not exists.");
    }

    public void CheckIfBlacklistNotExist(Blacklist blacklist)
    {
        var isExistApplicantId = _blacklistRepository.Get(x => x.ApplicantId == blacklist.ApplicantId) is not null;
        CheckForeginKeyIdExist(blacklist);
        if (isExistApplicantId) throw new BusinessException("Blacklist already exists.");
    }
}
