using Core.Entities;

namespace Entities.Concretes;

public class BootcampImage : BaseEntity<Guid>
{
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }

    public virtual Bootcamp Bootcamp { get; set; }

    public BootcampImage()
    {
        
    }

    public BootcampImage(Guid id, int bootcampId, string ımagePath)
    {
        Id = id;
        BootcampId = bootcampId;
        ImagePath = ımagePath;
    }
}
