using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ApplicantBusinessRules _applicantBusinessRules;
    private readonly IMapper _mapper;

    public ApplicantManager(IApplicantRepository applicantRepository, ApplicantBusinessRules applicantBusinessRules, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _applicantBusinessRules = applicantBusinessRules;
        _mapper = mapper;
    }

    [LogAspect(typeof(MongoDbLogger))]
    public IDataResult<CreateApplicantResponse> Add(CreateApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        _applicantBusinessRules.CheckIfApplicantNotExist(applicant);
        _applicantRepository.Add(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, ApplicantMessages.ApplicantAdded);
    }

    public void CheckExistById(int id)
    {
        _applicantBusinessRules.CheckIfApplicantIdExist(id);
    }

    public IResult Delete(int id)
    {
        _applicantBusinessRules.CheckIfApplicantIdExist(id);

        Applicant applicant = _applicantRepository.Get(x => x.Id == id);
        _applicantRepository.Delete(applicant);
        return new SuccessResult(ApplicantMessages.ApplicantDeleted);
    }

    [LogAspect(typeof(MssqlLogger))]
    public IDataResult<List<GetAllApplicantResponse>> GetAll()
    {
        List<Applicant> applicants = _applicantRepository.GetAll();
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, ApplicantMessages.ApplicantListed);
    }

    public IDataResult<GetByIdApplicantResponse> GetById(int id)
    {
        _applicantBusinessRules.CheckIfApplicantIdExist(id);

        Applicant applicant = _applicantRepository.Get(x => x.Id == id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, ApplicantMessages.ApplicantListed);
    }

    public IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request)
    {
        _applicantBusinessRules.CheckIfApplicantIdExist(request.Id);
        Applicant applicant = _applicantRepository.Get(u => u.Id == request.Id);

        applicant = _applicantBusinessRules.CheckApplicantUpdate(applicant, request);
        _applicantRepository.Update(applicant);

        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return new SuccessDataResult<UpdateApplicantResponse>(response, ApplicantMessages.ApplicantUpdated);
    }
}
