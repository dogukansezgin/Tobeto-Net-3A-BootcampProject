namespace Business.Responses.InstructorImages;

public class CreateInstructorImageResponse
{
    public Guid Id { get; set; }
    public int InstructorId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}
