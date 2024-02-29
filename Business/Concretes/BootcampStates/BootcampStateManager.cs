using AutoMapper;
using Business.Abstracts.BootcampStates;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.BootcampStates;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IBootcampStateValidator _bootcampStateValidator;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IBootcampStateValidator bootcampStateValidator, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _bootcampStateValidator = bootcampStateValidator;
        _mapper = mapper;
    }
    public IDataResult<CreateBootcampStateResponse> Add(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        _bootcampStateValidator.CheckIfBootcampStateNotExist(bootcampState);
        _bootcampStateRepository.Add(bootcampState);

        CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _bootcampStateValidator.CheckIfBootcampStateIdExist(id);
        BootcampState bootcampState = _bootcampStateRepository.Get(x => x.Id == id);
        _bootcampStateRepository.Delete(bootcampState);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllBootcampStateResponse>> GetAll()
    {
        List<BootcampState> bootcampState = _bootcampStateRepository.GetAll();
        List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampState);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdBootcampStateResponse> GetById(int id)
    {
        _bootcampStateValidator.CheckIfBootcampStateIdExist(id);
        BootcampState bootcampState = _bootcampStateRepository.Get(x => x.Id == id);
        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<GetByIdBootcampStateResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateBootcampStateResponse> Update(UpdateBootcampStateRequest request)
    {
        _bootcampStateValidator.CheckIfBootcampStateIdExist(request.Id);
        BootcampState bootcampState = _bootcampStateRepository.Get(u => u.Id == request.Id);

        _bootcampStateValidator.CheckBootcampStateUpdate(bootcampState, request);
        _bootcampStateRepository.Update(bootcampState);

        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Updated Succesfully");
    }
}
