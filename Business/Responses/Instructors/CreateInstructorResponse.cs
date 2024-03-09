namespace Business.Responses.Instructors;

public class CreateInstructorResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedDate { get; set; }
}
