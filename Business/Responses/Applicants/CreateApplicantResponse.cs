namespace Business.Responses.Applicants;

public class CreateApplicantResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string About { get; set; }
    public DateTime CreatedDate { get; set; }
}
