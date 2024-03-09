namespace Business.Responses.InstructorImages;

public class DeleteInstructorImageResponse
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
