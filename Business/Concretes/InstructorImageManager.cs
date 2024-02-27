using AutoMapper;
using Business.Abstracts;
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

    public InstructorImageManager(IInstructorImageRepository ınstructorımageRepository, IMapper mapper)
    {
        _instructorImageRepository = ınstructorımageRepository;
        _mapper = mapper;
    }

    public IDataResult<CreateInstructorImageResponse> Add(CreateInstructorImageRequest request)
    {
        InstructorImage instructorImage = _mapper.Map<InstructorImage>(request);
        _instructorImageRepository.Add(instructorImage);

        CreateInstructorImageResponse response = _mapper.Map<CreateInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<CreateInstructorImageResponse>(response, "Added Succesfully");
    }

    public IDataResult<DeleteInstructorImageResponse> Delete(DeleteInstructorImageRequest request)
    {
        InstructorImage instructorImage = _mapper.Map<InstructorImage>(request);
        _instructorImageRepository.Delete(instructorImage);

        DeleteInstructorImageResponse response = _mapper.Map<DeleteInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<DeleteInstructorImageResponse>(response, "Deleted Succesfully");
    }

    public IDataResult<List<GetAllInstructorImageResponse>> GetAll()
    {
        List<InstructorImage> instructorImages = _instructorImageRepository.GetAll(include: x => x.Include(x => x.Instructor));
        List<GetAllInstructorImageResponse> responses = _mapper.Map<List<GetAllInstructorImageResponse>>(instructorImages);
        return new SuccessDataResult<List<GetAllInstructorImageResponse>>(responses, "Listed Succesfully");
    }

    public IDataResult<GetByIdInstructorImageResponse> GetById(Guid id)
    {
        InstructorImage instructorImage = _instructorImageRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Instructor));
        GetByIdInstructorImageResponse response = _mapper.Map<GetByIdInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<GetByIdInstructorImageResponse>(response, "Listed Succesfully");
    }

    public IDataResult<UpdateInstructorImageResponse> Update(UpdateInstructorImageRequest request)
    {
        InstructorImage instructorImage = _instructorImageRepository.Get(x => x.Id == request.Id);
        instructorImage.InstructorId = request.InstructorId ?? instructorImage.InstructorId;
        instructorImage.ImagePath = request.ImagePath ?? instructorImage.ImagePath;
        instructorImage.UpdatedDate = DateTime.UtcNow;
        _instructorImageRepository.Update(instructorImage);

        UpdateInstructorImageResponse response = _mapper.Map<UpdateInstructorImageResponse>(instructorImage);
        return new SuccessDataResult<UpdateInstructorImageResponse>(response, "Updated Succesfully");
    }
}
