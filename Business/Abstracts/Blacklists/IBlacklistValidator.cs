using Business.Requests.Blacklists;
using Entities.Concretes;

namespace Business.Abstracts.Blacklists;

public interface IBlacklistValidator
{
    void CheckIfBlacklistNotExist(Blacklist blacklist);
    void CheckIfBlacklistIdExist(int id);
    void CheckForeginKeyIdExist(Blacklist blacklist);
    Blacklist CheckBlacklistUpdate(Blacklist blacklist, UpdateBlacklistRequest request);
}
