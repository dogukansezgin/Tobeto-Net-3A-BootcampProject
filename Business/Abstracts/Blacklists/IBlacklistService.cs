using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;

namespace Business.Abstracts.Blacklists;

public interface IBlacklistService
{
    IDataResult<CreateBlacklistResponse> Add(CreateBlacklistRequest request);
    IResult Delete(int id);
    IDataResult<UpdateBlacklistResponse> Update(UpdateBlacklistRequest request);
    IDataResult<GetByIdBlacklistResponse> GetById(int id);
    IDataResult<List<GetAllBlacklistResponse>> GetAll();
}
