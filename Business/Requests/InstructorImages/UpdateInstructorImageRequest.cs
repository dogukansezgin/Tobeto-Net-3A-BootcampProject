namespace Business.Requests.InstructorImages;

public class UpdateInstructorImageRequest
{
    public Guid Id { get; set; }
    public Guid? InstructorId { get; set; }
    public string? ImagePath { get; set; }
}
