using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.InstructorImages;
using Business.Responses.InstructorImages;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class InstructorImageManager : IInstructorImageService
{
    private readonly IInstructorImageRepository _instructorImageRepository;
    private readonly IMapper _mapper;

    public InstructorImageManager(IInstructorImageRepository instructorImageRepository, IMapper mapper)
    {
        _instructorImageRepository = instructorImageRepository;
        _mapper = mapper;
    }

    public IDataResult<CreateInstructorImageResponse> Add(CreateInstructorImageRequest request)
    {
        InstructorImage instructorImage = _mapper.Map<InstructorImage>(request);
        _instructorImageRepository.Add(instructorImage);

        CreateInstructorImageResponse response = _mapper.Map<CreateInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<CreateInstructorImageResponse>(response, InstructorImageMessages.InstructorImageAdded);
    }

    public IResult Delete(Guid id)
    {
        InstructorImage instructorImage = _instructorImageRepository.Get(x => x.Id == id);
        _instructorImageRepository.Delete(instructorImage);
        return new SuccessResult(InstructorImageMessages.InstructorImageDeleted);
    }

    public IDataResult<List<GetAllInstructorImageResponse>> GetAll()
    {
        List<InstructorImage> instructorImages = _instructorImageRepository.GetAll(include: x => x.Include(x => x.Instructor));
        List<GetAllInstructorImageResponse> responses = _mapper.Map<List<GetAllInstructorImageResponse>>(instructorImages);
        return new SuccessDataResult<List<GetAllInstructorImageResponse>>(responses, InstructorImageMessages.InstructorImageListed);
    }

    public IDataResult<GetByIdInstructorImageResponse> GetById(Guid id)
    {
        InstructorImage instructorImage = _instructorImageRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Instructor));
        GetByIdInstructorImageResponse response = _mapper.Map<GetByIdInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<GetByIdInstructorImageResponse>(response, InstructorImageMessages.InstructorImageListed);
    }

    public IDataResult<UpdateInstructorImageResponse> Update(UpdateInstructorImageRequest request)
    {
        InstructorImage instructorImage = _instructorImageRepository.Get(x => x.Id == request.Id);
        instructorImage.InstructorId = request.InstructorId ?? instructorImage.InstructorId;
        instructorImage.ImagePath = request.ImagePath ?? instructorImage.ImagePath;
        instructorImage.UpdatedDate = DateTime.UtcNow;
        _instructorImageRepository.Update(instructorImage);

        UpdateInstructorImageResponse response = _mapper.Map<UpdateInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<UpdateInstructorImageResponse>(response, InstructorImageMessages.InstructorImageUpdated);
    }
}
