using AutoMapper;
using Business.Abstracts;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IMapper _mapper;

    public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
    }

    public IDataResult<CreateBlacklistResponse> Add(CreateBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        _blacklistRepository.Add(blacklist);

        CreateBlacklistResponse response = _mapper.Map<CreateBlacklistResponse>(blacklist);
        return new SuccessDataResult<CreateBlacklistResponse>(response, "Added Succesfully");
    }

    public IDataResult<DeleteBlacklistResponse> Delete(DeleteBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        _blacklistRepository.Delete(blacklist);

        DeleteBlacklistResponse response = _mapper.Map<DeleteBlacklistResponse>(blacklist);
        return new SuccessDataResult<DeleteBlacklistResponse>(response, "Deleted Succesfully");
    }

    public IDataResult<List<GetAllBlacklistResponse>> GetAll()
    {
        List<Blacklist> blacklists = _blacklistRepository.GetAll(include: x => x.Include(x => x.Applicant));
        List<GetAllBlacklistResponse> responses = _mapper.Map<List<GetAllBlacklistResponse>>(blacklists);
        return new SuccessDataResult<List<GetAllBlacklistResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdBlacklistResponse> GetById(int id)
    {
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Applicant));
        GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(blacklist);
        return new SuccessDataResult<GetByIdBlacklistResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateBlacklistResponse> Update(UpdateBlacklistRequest request)
    {
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == request.Id);
        blacklist.ApplicantId = request.ApplicantId ?? blacklist.ApplicantId;
        blacklist.Reason = request.Reason ?? blacklist.Reason;
        blacklist.Date = request.Date ?? blacklist.Date;
        blacklist.UpdatedDate = DateTime.UtcNow;
        _blacklistRepository.Update(blacklist);

        UpdateBlacklistResponse response = _mapper.Map<UpdateBlacklistResponse>(blacklist);
        return new SuccessDataResult<UpdateBlacklistResponse>(response, "Updated Succesfully");
    }
}
