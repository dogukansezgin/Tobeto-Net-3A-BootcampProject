namespace Business.Requests.InstructorImages;

public class CreateInstructorImageRequest
{
    public int InstructorId { get; set; }
    public string ImagePath { get; set; }
}
