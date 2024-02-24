using Core.Entities;

namespace Entities.Concretes;

public class Bootcamp : BaseEntity<int>
{
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual Instructor? Instructor { get; set; }
    public virtual BootcampState? BootcampState { get; set; }
    public virtual ICollection<BootcampImage> BootcampImages { get; set; }

    public Bootcamp()
    {
        BootcampImages = new HashSet<BootcampImage>();
    }

    public Bootcamp(int id, string name, int ınstructorId, int bootcampStateId, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Name = name;
        InstructorId = ınstructorId;
        BootcampStateId = bootcampStateId;
        StartDate = startDate;
        EndDate = endDate;
    }
}
