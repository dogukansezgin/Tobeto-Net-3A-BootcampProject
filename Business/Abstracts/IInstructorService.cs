using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IInstructorService
{
    IDataResult<CreateInstructorResponse> Add(CreateInstructorRequest request);
    IResult Delete(int id);
    IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request);
    IDataResult<GetByIdInstructorResponse> GetById(int id);
    IDataResult<List<GetAllInstructorResponse>> GetAll();
}
