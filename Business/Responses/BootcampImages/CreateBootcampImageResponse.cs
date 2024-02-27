namespace Business.Responses.BootcampImages;

public class CreateBootcampImageResponse
{
    public Guid Id { get; set; }
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}
