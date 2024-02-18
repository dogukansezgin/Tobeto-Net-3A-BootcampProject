namespace Business.Responses.Instructors;

public class DeleteInstructorResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
