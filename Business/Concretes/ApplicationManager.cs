using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public CreateApplicationResponse Add(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        _applicationRepository.Add(application);

        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return response;
    }

    public DeleteApplicationResponse Delete(DeleteApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        _applicationRepository.Delete(application);

        DeleteApplicationResponse response = _mapper.Map<DeleteApplicationResponse>(application);
        return response;
    }

    public List<GetAllApplicationResponse> GetAll()
    {
        List<Application> applications = _applicationRepository.GetAll(include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return responses;
    }

    public GetByIdApplicationResponse GetById(int id)
    {
        Application application = _applicationRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
        return response;
    }

    public UpdateApplicationResponse Update(UpdateApplicationRequest request)
    {
        Application application = _applicationRepository.Get(x => x.Id == request.Id);
        application.ApplicantId = request.ApplicantId;
        application.BootcampId = request.BootcampId;
        application.ApplicationStateId = request.ApplicationStateId;
        application.UpdatedDate = DateTime.UtcNow;
        _applicationRepository.Update(application);

        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
        return response;
    }
}
