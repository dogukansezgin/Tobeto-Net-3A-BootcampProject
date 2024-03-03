using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly BootcampBusinessRules _bootcampBusinessRules;
    private readonly IMapper _mapper;

    public BootcampManager(IBootcampRepository bootcampRepository, BootcampBusinessRules bootcampBusinessRules, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _bootcampBusinessRules = bootcampBusinessRules;
        _mapper = mapper;
    }

    public IDataResult<CreateBootcampResponse> Add(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
        _bootcampRepository.Add(bootcamp);

        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response, BootcampMessages.BootcampAdded);
    }

    public void CheckExistById(int id)
    {
        _bootcampBusinessRules.CheckIfBootcampIdExist(id);
    }

    public IResult Delete(int id)
    {
        _bootcampBusinessRules.CheckIfBootcampIdExist(id);
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == id);
        _bootcampRepository.Delete(bootcamp);
        return new SuccessResult(BootcampMessages.BootcampDeleted);
    }

    public IDataResult<List<GetAllBootcampResponse>> GetAll()
    {
        List<Bootcamp> bootcamps = _bootcampRepository.GetAll(include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responses, BootcampMessages.BootcampListed);
    }

    public IDataResult<GetByIdBootcampResponse> GetById(int id)
    {
        _bootcampBusinessRules.CheckIfBootcampIdExist(id);
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return new SuccessDataResult<GetByIdBootcampResponse>(response, BootcampMessages.BootcampListed);
    }

    public IDataResult<UpdateBootcampResponse> Update(UpdateBootcampRequest request)
    {
        _bootcampBusinessRules.CheckIfBootcampIdExist(request.Id);
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == request.Id);

        _bootcampBusinessRules.CheckBootcampUpdate(bootcamp, request);
        _bootcampRepository.Update(bootcamp);

        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
        return new SuccessDataResult<UpdateBootcampResponse>(response, BootcampMessages.BootcampUpdated);
    }
}
