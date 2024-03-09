namespace Business.Requests.Applicants;

public class DeleteApplicantRequest
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
}
