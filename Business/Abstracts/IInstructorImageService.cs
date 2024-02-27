using Business.Requests.InstructorImages;
using Business.Responses.InstructorImages;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IInstructorImageService
{
    IDataResult<CreateInstructorImageResponse> Add(CreateInstructorImageRequest request);
    IDataResult<DeleteInstructorImageResponse> Delete(DeleteInstructorImageRequest request);
    IDataResult<UpdateInstructorImageResponse> Update(UpdateInstructorImageRequest request);
    IDataResult<GetByIdInstructorImageResponse> GetById(Guid id);
    IDataResult<List<GetAllInstructorImageResponse>> GetAll();
}