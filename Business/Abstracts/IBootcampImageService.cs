using Business.Requests.BootcampImages;
using Business.Responses.BootcampImages;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampImageService
{
    IDataResult<CreateBootcampImageResponse> Add(CreateBootcampImageRequest request);
    IDataResult<DeleteBootcampImageResponse> Delete(DeleteBootcampImageRequest request);
    IDataResult<UpdateBootcampImageResponse> Update(UpdateBootcampImageRequest request);
    IDataResult<GetByIdBootcampImageResponse> GetById(Guid id);
    IDataResult<List<GetAllBootcampImageResponse>> GetAll();
}
