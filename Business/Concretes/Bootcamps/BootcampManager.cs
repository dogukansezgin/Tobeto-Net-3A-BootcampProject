using AutoMapper;
using Business.Abstracts.Bootcamps;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes.Bootcamps;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IBootcampValidator _bootcampValidator;
    private readonly IMapper _mapper;

    public BootcampManager(IBootcampRepository bootcampRepository, IBootcampValidator bootcampValidator, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _bootcampValidator = bootcampValidator;
        _mapper = mapper;
    }

    public IDataResult<CreateBootcampResponse> Add(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        _bootcampValidator.CheckIfBootcampNotExist(bootcamp);
        _bootcampRepository.Add(bootcamp);

        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _bootcampValidator.CheckIfBootcampIdExist(id);
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == id);
        _bootcampRepository.Delete(bootcamp);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllBootcampResponse>> GetAll()
    {
        List<Bootcamp> bootcamps = _bootcampRepository.GetAll(include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdBootcampResponse> GetById(int id)
    {
        _bootcampValidator.CheckIfBootcampIdExist(id);
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return new SuccessDataResult<GetByIdBootcampResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateBootcampResponse> Update(UpdateBootcampRequest request)
    {
        _bootcampValidator.CheckIfBootcampIdExist(request.Id);
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == request.Id);

        _bootcampValidator.CheckBootcampUpdate(bootcamp, request);
        _bootcampRepository.Update(bootcamp);

        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
        return new SuccessDataResult<UpdateBootcampResponse>(response, "Updated Succesfully");
    }
}
