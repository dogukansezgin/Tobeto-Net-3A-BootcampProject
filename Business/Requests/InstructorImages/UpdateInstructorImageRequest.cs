namespace Business.Requests.InstructorImages;

public class UpdateInstructorImageRequest
{
    public Guid Id { get; set; }
    public int? InstructorId { get; set; }
    public string? ImagePath { get; set; }
}
