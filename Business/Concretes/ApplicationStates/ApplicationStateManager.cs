using AutoMapper;
using Business.Abstracts.ApplicatonStates;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.ApplicationStates;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly IApplicationStateValidator _applicationStateValidator;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IApplicationStateValidator applicationStateValidator, IMapper mapper)
    {
        _applicationStateRepository = applicationStateRepository;
        _applicationStateValidator = applicationStateValidator;
        _mapper = mapper;
    }

    public IDataResult<CreateApplicationStateResponse> Add(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        _applicationStateValidator.CheckIfApplicationStateNotExist(applicationState);
        _applicationStateRepository.Add(applicationState);

        CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<CreateApplicationStateResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _applicationStateValidator.CheckIfApplicationStateIdExist(id);
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == id);
        _applicationStateRepository.Delete(applicationState);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllApplicationStateResponse>> GetAll()
    {
        List<ApplicationState> applicationState = _applicationStateRepository.GetAll();
        List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationState);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdApplicationStateResponse> GetById(int id)
    {
        _applicationStateValidator.CheckIfApplicationStateIdExist(id);
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == id);
        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
        return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateApplicationStateResponse> Update(UpdateApplicationStateRequest request)
    {
        _applicationStateValidator.CheckIfApplicationStateIdExist(request.Id);
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == request.Id);

        applicationState = _applicationStateValidator.CheckApplicationStateUpdate(applicationState, request);
        _applicationStateRepository.Update(applicationState);

        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Updated Succesfully");
    }
}
