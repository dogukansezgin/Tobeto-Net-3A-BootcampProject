using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBlacklistService
{
    IDataResult<CreateBlacklistResponse> Add(CreateBlacklistRequest request);
    IResult Delete(int id);
    IDataResult<UpdateBlacklistResponse> Update(UpdateBlacklistRequest request);
    IDataResult<GetByIdBlacklistResponse> GetById(int id);
    IDataResult<List<GetAllBlacklistResponse>> GetAll();
    void CheckExistById(int id);
    void CheckIfApplicantBlacklisted(Guid applicantId);
}
