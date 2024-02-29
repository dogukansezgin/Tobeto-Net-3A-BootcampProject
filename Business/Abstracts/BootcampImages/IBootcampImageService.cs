using Business.Requests.BootcampImages;
using Business.Responses.BootcampImages;
using Core.Utilities.Results;

namespace Business.Abstracts.BootcampImages;

public interface IBootcampImageService
{
    IDataResult<CreateBootcampImageResponse> Add(CreateBootcampImageRequest request);
    IResult Delete(Guid id);
    IDataResult<UpdateBootcampImageResponse> Update(UpdateBootcampImageRequest request);
    IDataResult<GetByIdBootcampImageResponse> GetById(Guid id);
    IDataResult<List<GetAllBootcampImageResponse>> GetAll();
}
