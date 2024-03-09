namespace Business.Requests.InstructorImages;

public class CreateInstructorImageRequest
{
    public Guid InstructorId { get; set; }
    public string ImagePath { get; set; }
}
