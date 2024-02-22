using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;

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

    public CreateBootcampResponse Add(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        _bootcampRepository.Add(bootcamp);

        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return response;
    }

    public DeleteBootcampResponse Delete(DeleteBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        _bootcampRepository.Delete(bootcamp);

        DeleteBootcampResponse response = _mapper.Map<DeleteBootcampResponse>(bootcamp);
        return response;
    }

    public List<GetAllBootcampResponse> GetAll()
    {
        List<Bootcamp> bootcamps = _bootcampRepository.GetAll();
        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return responses;
    }

    public GetByIdBootcampResponse GetById(int id)
    {
        Bootcamp bootcamp = _bootcampRepository.Get(x => x.Id == id);
        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return response;
    }

    public UpdateBootcampResponse Update(UpdateBootcampRequest request)
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
        return response;
    }
}
