using AutoMapper;
using Business.Abstracts;
using Business.Constants.Messages;
using Business.Requests.BootcampImages;
using Business.Responses.BootcampImages;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BootcampImageManager : IBootcampImageService
{
    private readonly IBootcampImageRepository _bootcampImageRepository;
    private readonly IMapper _mapper;

    public BootcampImageManager(IBootcampImageRepository bootcampImageRepository, IMapper mapper)
    {
        _bootcampImageRepository = bootcampImageRepository;
        _mapper = mapper;
    }

    public IDataResult<CreateBootcampImageResponse> Add(CreateBootcampImageRequest request)
    {
        BootcampImage bootcampImage = _mapper.Map<BootcampImage>(request);
        _bootcampImageRepository.Add(bootcampImage);

        CreateBootcampImageResponse response = _mapper.Map<CreateBootcampImageResponse>(bootcampImage);
        return new SuccessDataResult<CreateBootcampImageResponse>(response, BootcampImageMessages.BootcampImageAdded);
    }

    public IResult Delete(Guid id)
    {
        BootcampImage bootcampImage = _bootcampImageRepository.Get(x => x.Id == id);
        _bootcampImageRepository.Delete(bootcampImage);
        return new SuccessResult(BootcampImageMessages.BootcampImageDeleted);
    }

    public IDataResult<List<GetAllBootcampImageResponse>> GetAll()
    {
        List<BootcampImage> bootcampImage = _bootcampImageRepository.GetAll(include: x => x.Include(x => x.Bootcamp));
        List<GetAllBootcampImageResponse> responses = _mapper.Map<List<GetAllBootcampImageResponse>>(bootcampImage);
        return new SuccessDataResult<List<GetAllBootcampImageResponse>>(responses, BootcampImageMessages.BootcampImageListed);
    }

    public IDataResult<GetByIdBootcampImageResponse> GetById(Guid id)
    {
        BootcampImage bootcampImage = _bootcampImageRepository.Get(x => x.Id == id, include: x => x.Include(x => x.Bootcamp));
        GetByIdBootcampImageResponse response = _mapper.Map<GetByIdBootcampImageResponse>(bootcampImage);
        return new SuccessDataResult<GetByIdBootcampImageResponse>(response, BootcampImageMessages.BootcampImageListed);
    }

    public IDataResult<UpdateBootcampImageResponse> Update(UpdateBootcampImageRequest request)
    {
        BootcampImage bootcampImage = _bootcampImageRepository.Get(x => x.Id == request.Id);
        bootcampImage.BootcampId = request.BootcampId ?? bootcampImage.BootcampId;
        bootcampImage.ImagePath = request.ImagePath ?? bootcampImage.ImagePath;
        bootcampImage.UpdatedDate = DateTime.UtcNow;
        _bootcampImageRepository.Update(bootcampImage);

        UpdateBootcampImageResponse response = _mapper.Map<UpdateBootcampImageResponse>(bootcampImage);
        return new SuccessDataResult<UpdateBootcampImageResponse>(response, BootcampImageMessages.BootcampImageUpdated);
    }
}
