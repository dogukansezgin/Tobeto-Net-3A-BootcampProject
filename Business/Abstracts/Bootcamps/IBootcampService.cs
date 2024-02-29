using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;

namespace Business.Abstracts.Bootcamps;

public interface IBootcampService
{
    IDataResult<CreateBootcampResponse> Add(CreateBootcampRequest request);
    IResult Delete(int id);
    IDataResult<UpdateBootcampResponse> Update(UpdateBootcampRequest request);
    IDataResult<GetByIdBootcampResponse> GetById(int id);
    IDataResult<List<GetAllBootcampResponse>> GetAll();
}
