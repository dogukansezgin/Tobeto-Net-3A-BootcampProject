using Core.Entities;

namespace Entities.Concretes;

public class InstructorImage : BaseEntity<Guid>
{
    public int InstructorId { get; set; }
    public string ImagePath { get; set; }

    public virtual Instructor Instructor { get; set; }

    public InstructorImage()
    {
        
    }

    public InstructorImage(Guid id, int ınstructorId, string ımagePath)
    {
        Id = id;
        InstructorId = ınstructorId;
        ImagePath = ımagePath;
    }
}
