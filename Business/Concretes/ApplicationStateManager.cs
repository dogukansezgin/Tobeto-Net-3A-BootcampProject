using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper)
    {
        _applicationStateRepository = applicationStateRepository;
        _mapper = mapper;
    }

    public CreateApplicationStateResponse Add(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        _applicationStateRepository.Add(applicationState);

        CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
        return response;
    }

    public DeleteApplicationStateResponse Delete(DeleteApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        _applicationStateRepository.Delete(applicationState);

        DeleteApplicationStateResponse response = _mapper.Map<DeleteApplicationStateResponse>(applicationState);
        return response;
    }

    public List<GetAllApplicationStateResponse> GetAll()
    {
        List<ApplicationState> applicationState = _applicationStateRepository.GetAll();
        List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationState);
        return responses;
    }

    public GetByIdApplicationStateResponse GetById(int id)
    {
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == id);
        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
        return response;
    }

    public UpdateApplicationStateResponse Update(UpdateApplicationStateRequest request)
    {
        ApplicationState applicationState = _applicationStateRepository.Get(x => x.Id == request.Id);
        applicationState.Name = request.Name ?? applicationState.Name;
        applicationState.UpdatedDate = DateTime.UtcNow;
        _applicationStateRepository.Update(applicationState);

        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
        return response;
    }
}
