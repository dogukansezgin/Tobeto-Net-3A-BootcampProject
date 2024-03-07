namespace Business.Responses.BootcampImages;

public class GetAllBootcampImageResponse
{
    public Guid Id { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public int BootcampInstructorId { get; set; }
    public int BootcampBootcampStateId { get; set; }
    public DateTime BootcampStartDate { get; set; }
    public DateTime BootcampEndDate { get; set; }
    public DateTime BootcampCreatedDate { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
