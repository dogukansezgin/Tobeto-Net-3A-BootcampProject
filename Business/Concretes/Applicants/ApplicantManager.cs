using AutoMapper;
using Business.Abstracts.Applicants;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes.Applicants;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IApplicantValidator _applicantValidator;
    private readonly IMapper _mapper;

    public ApplicantManager(IApplicantRepository applicantRepository, IApplicantValidator applicantValidator, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _applicantValidator = applicantValidator;
        _mapper = mapper;
    }

    public IDataResult<CreateApplicantResponse> Add(CreateApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        _applicantValidator.CheckIfApplicantNotExist(applicant);
        _applicantRepository.Add(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, "Added Succesfully");
    }

    public IResult Delete(int id)
    {
        _applicantValidator.CheckIfApplicantIdExist(id);

        Applicant applicant = _applicantRepository.Get(x => x.Id == id);
        _applicantRepository.Delete(applicant);
        return new SuccessResult("Deleted Succesfully");
    }

    public IDataResult<List<GetAllApplicantResponse>> GetAll()
    {
        List<Applicant> applicants = _applicantRepository.GetAll();
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdApplicantResponse> GetById(int id)
    {
        _applicantValidator.CheckIfApplicantIdExist(id);

        Applicant applicant = _applicantRepository.Get(x => x.Id == id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request)
    {
        _applicantValidator.CheckIfApplicantIdExist(request.Id);
        Applicant applicant = _applicantRepository.Get(u => u.Id == request.Id);

        applicant = _applicantValidator.CheckApplicantUpdate(applicant, request);
        _applicantRepository.Update(applicant);

        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return new SuccessDataResult<UpdateApplicantResponse>(response, "Updated Succesfully");
    }
}
