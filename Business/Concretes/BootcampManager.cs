using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
    }

    public IDataResult<CreateBootcampResponse> Add(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        _bootcampRepository.Add(bootcamp);

        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
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
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return new SuccessDataResult<GetByIdBootcampResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateBootcampResponse> Update(UpdateBootcampRequest request)
    {
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == request.Id);
        bootcamp.Name = request.Name ?? bootcamp.Name;
        bootcamp.InstructorId = request.InstructorId ?? bootcamp.InstructorId;
        bootcamp.BootcampStateId = request.BootcampStateId ?? bootcamp.BootcampStateId;
        bootcamp.StartDate = request.StartDate ?? bootcamp.StartDate;
        bootcamp.EndDate = request.EndDate ?? bootcamp.EndDate;
        bootcamp.UpdatedDate = DateTime.UtcNow;
        _bootcampRepository.Update(bootcamp);

        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
        return new SuccessDataResult<UpdateBootcampResponse>(response, "Updated Succesfully");
    }
}
