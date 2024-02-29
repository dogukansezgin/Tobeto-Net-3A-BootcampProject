using AutoMapper;
using Business.Abstracts.Blacklists;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes.Blacklists;

public class BlacklistManager : IBlacklistService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IBlacklistValidator _blacklistValidator;
    private readonly IMapper _mapper;

    public BlacklistManager(IBlacklistRepository blacklistRepository, IBlacklistValidator blacklistValidator, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _blacklistValidator = blacklistValidator;
        _mapper = mapper;
    }

    public IDataResult<CreateBlacklistResponse> Add(CreateBlacklistRequest request)
    {
        Blacklist blacklist = _mapper.Map<Blacklist>(request);
        _blacklistValidator.CheckIfBlacklistNotExist(blacklist);
        _blacklistRepository.Add(blacklist);

        CreateBlacklistResponse response = _mapper.Map<CreateBlacklistResponse>(blacklist);
        return new SuccessDataResult<CreateBlacklistResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _blacklistValidator.CheckIfBlacklistIdExist(id);
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == id);
        _blacklistRepository.Delete(blacklist);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllBlacklistResponse>> GetAll()
    {
        List<Blacklist> blacklists = _blacklistRepository.GetAll(include: x => x.Include(x => x.Applicant));
        List<GetAllBlacklistResponse> responses = _mapper.Map<List<GetAllBlacklistResponse>>(blacklists);
        return new SuccessDataResult<List<GetAllBlacklistResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdBlacklistResponse> GetById(int id)
    {
        _blacklistValidator.CheckIfBlacklistIdExist(id);
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Applicant));
        GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(blacklist);
        return new SuccessDataResult<GetByIdBlacklistResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateBlacklistResponse> Update(UpdateBlacklistRequest request)
    {
        _blacklistValidator.CheckIfBlacklistIdExist(request.Id);
        Blacklist blacklist = _blacklistRepository.Get(x => x.Id == request.Id);
        
        _blacklistValidator.CheckBlacklistUpdate(blacklist, request);
        _blacklistRepository.Update(blacklist);

        UpdateBlacklistResponse response = _mapper.Map<UpdateBlacklistResponse>(blacklist);
        return new SuccessDataResult<UpdateBlacklistResponse>(response, "Updated Succesfully");
    }
}
