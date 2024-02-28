using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
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

    public IDataResult<CreateApplicationResponse> Add(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        _applicationRepository.Add(application);

        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return new SuccessDataResult<CreateApplicationResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        Application application = _applicationRepository.Get(x => x.Id == id);
        _applicationRepository.Delete(application);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllApplicationResponse>> GetAll()
    {
        List<Application> applications = _applicationRepository.GetAll(include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdApplicationResponse> GetById(int id)
    {
        Application application = _applicationRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
        return new SuccessDataResult<GetByIdApplicationResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateApplicationResponse> Update(UpdateApplicationRequest request)
    {
        Application application = _applicationRepository.Get(x => x.Id == request.Id);
        application.ApplicantId = request.ApplicantId;
        application.BootcampId = request.BootcampId;
        application.ApplicationStateId = request.ApplicationStateId;
        application.UpdatedDate = DateTime.UtcNow;
        _applicationRepository.Update(application);

        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
        return new SuccessDataResult<UpdateApplicationResponse>(response, "Updated Succesfully");
    }
}
