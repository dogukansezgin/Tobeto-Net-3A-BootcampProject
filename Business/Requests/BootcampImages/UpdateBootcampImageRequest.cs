namespace Business.Requests.BootcampImages;

public class UpdateBootcampImageRequest
{
    public Guid Id { get; set; }
    public int? BootcampId { get; set; }
    public string? ImagePath { get; set; }
}
