using Business.Requests.Applications;
using Entities.Concretes;

namespace Business.Abstracts.Applications;

public interface IApplicationValidator
{
    void CheckIfApplicationNotExist(Application application);
    void CheckIfApplicationIdExist(int id);
    void CheckForeginKeyIdExist(Application application);
    void CheckIsInBlacklist(int applicantId);
    Application CheckApplicationUpdate(Application application, UpdateApplicationRequest request);
}
