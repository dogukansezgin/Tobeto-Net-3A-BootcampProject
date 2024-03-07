using Core.Entities;

namespace Entities.Concretes;

public class Application : BaseEntity<int>
{
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }
    public virtual ApplicationState? ApplicationState { get; set; }

    public Application()
    {
        
    }

    public Application(int id, Guid applicantId, int bootcampId, int applicationStateId)
    {
        Id = id;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStateId;
    }
}
