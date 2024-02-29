using Business.Requests.InstructorImages;
using Business.Responses.InstructorImages;
using Core.Utilities.Results;

namespace Business.Abstracts.InstructorImages;

public interface IInstructorImageService
{
    IDataResult<CreateInstructorImageResponse> Add(CreateInstructorImageRequest request);
    IResult Delete(Guid id);
    IDataResult<UpdateInstructorImageResponse> Update(UpdateInstructorImageRequest request);
    IDataResult<GetByIdInstructorImageResponse> GetById(Guid id);
    IDataResult<List<GetAllInstructorImageResponse>> GetAll();
}