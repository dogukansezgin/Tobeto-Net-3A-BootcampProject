using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IInstructorService
{
    IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request);
    IResult Delete(Guid id);
    IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request);
    IDataResult<GetByIdInstructorResponse> GetById(Guid id);
    IDataResult<List<GetAllInstructorResponse>> GetAll();
    void CheckExistById(Guid id);

}
