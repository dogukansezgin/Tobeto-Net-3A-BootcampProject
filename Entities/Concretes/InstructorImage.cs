using Core.Entities;

namespace Entities.Concretes;

public class InstructorImage : BaseEntity<Guid>
{
    public Guid InstructorId { get; set; }
    public string ImagePath { get; set; }

    public virtual Instructor Instructor { get; set; }

    public InstructorImage()
    {
        
    }

    public InstructorImage(Guid id, Guid instructorId, string ımagePath)
    {
        Id = id;
        InstructorId = instructorId;
        ImagePath = ımagePath;
    }
}
