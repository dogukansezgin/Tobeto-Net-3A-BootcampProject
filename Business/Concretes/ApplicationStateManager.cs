using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly ApplicationStateBusinessRules _applicationStateBusinessRules;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, ApplicationStateBusinessRules applicationStateBusinessRules, IMapper mapper)
    {
        _applicationStateRepository = applicationStateRepository;
        _applicationStateBusinessRules = applicationStateBusinessRules;
        _mapper = mapper;
    }

    public IDataResult<CreateApplicationStateResponse> Add(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        _applicationStateBusinessRules.CheckIfApplicationStateNotExist(applicationState);
        _applicationStateRepository.Add(applicationState);

        CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<CreateApplicationStateResponse>(response, "Added Succesfully");
    }

    public void CheckExistById(int id)
    {
        _applicationStateBusinessRules.CheckIfApplicationStateIdExist(id);
    }

    public IResult Delete(int id)
    {
        _applicationStateBusinessRules.CheckIfApplicationStateIdExist(id);
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
        _applicationStateBusinessRules.CheckIfApplicationStateIdExist(id);
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == id);
        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
        return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateApplicationStateResponse> Update(UpdateApplicationStateRequest request)
    {
        _applicationStateBusinessRules.CheckIfApplicationStateIdExist(request.Id);
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == request.Id);

        applicationState = _applicationStateBusinessRules.CheckApplicationStateUpdate(applicationState, request);
        _applicationStateRepository.Update(applicationState);

        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Updated Succesfully");
    }
}
