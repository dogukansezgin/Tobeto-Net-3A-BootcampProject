using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly BlacklistBusinessRules _blacklistBusinessRules;
    private readonly IMapper _mapper;

    public BlacklistManager(IBlacklistRepository blacklistRepository, BlacklistBusinessRules blacklistBusinessRules, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _blacklistBusinessRules = blacklistBusinessRules;
        _mapper = mapper;
    }

    public IDataResult<CreateBlacklistResponse> Add(CreateBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        _blacklistBusinessRules.CheckIfBlacklistNotExist(blacklist);
        _blacklistRepository.Add(blacklist);

        CreateBlacklistResponse response = _mapper.Map<CreateBlacklistResponse>(blacklist);
        return new SuccessDataResult<CreateBlacklistResponse>(response, BlacklistMessages.BlacklistAdded);
    }

    public void CheckExistById(int id)
    {
        _blacklistBusinessRules.CheckIfBlacklistIdExist(id);
    }

    public void CheckIfApplicantBlacklisted(int applicantId)
    {
        _blacklistBusinessRules.CheckIfApplicantBlacklisted(applicantId);
    }

    public IResult Delete(int id)
    {
        _blacklistBusinessRules.CheckIfBlacklistIdExist(id);
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == id);
        _blacklistRepository.Delete(blacklist);
        return new SuccessResult(BlacklistMessages.BlacklistDeleted);
    }

    public IDataResult<List<GetAllBlacklistResponse>> GetAll()
    {
        List<Blacklist> blacklists = _blacklistRepository.GetAll(include: x => x.Include(x => x.Applicant));
        List<GetAllBlacklistResponse> responses = _mapper.Map<List<GetAllBlacklistResponse>>(blacklists);
        return new SuccessDataResult<List<GetAllBlacklistResponse>>(responses, BlacklistMessages.BlacklistListed);
    }

    public IDataResult<GetByIdBlacklistResponse> GetById(int id)
    {
        _blacklistBusinessRules.CheckIfBlacklistIdExist(id);
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Applicant));
        GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(blacklist);
        return new SuccessDataResult<GetByIdBlacklistResponse>(response, BlacklistMessages.BlacklistListed);
    }

    public IDataResult<UpdateBlacklistResponse> Update(UpdateBlacklistRequest request)
    {
        _blacklistBusinessRules.CheckIfBlacklistIdExist(request.Id);
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == request.Id);

        _blacklistBusinessRules.CheckBlacklistUpdate(blacklist, request);
        _blacklistRepository.Update(blacklist);

        UpdateBlacklistResponse response = _mapper.Map<UpdateBlacklistResponse>(blacklist);
        return new SuccessDataResult<UpdateBlacklistResponse>(response, BlacklistMessages.BlacklistUpdated);
    }
}
