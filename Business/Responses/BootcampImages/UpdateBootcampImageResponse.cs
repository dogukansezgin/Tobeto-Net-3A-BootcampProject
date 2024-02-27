namespace Business.Responses.BootcampImages;

public class UpdateBootcampImageResponse
{
    public Guid Id { get; set; }
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
