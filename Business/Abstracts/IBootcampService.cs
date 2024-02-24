using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampService
{
    IDataResult<CreateBootcampResponse> Add(CreateBootcampRequest request);
    IDataResult<DeleteBootcampResponse> Delete(DeleteBootcampRequest request);
    IDataResult<UpdateBootcampResponse> Update(UpdateBootcampRequest request);
    IDataResult<GetByIdBootcampResponse> GetById(int id);
    IDataResult<List<GetAllBootcampResponse>> GetAll();
}
