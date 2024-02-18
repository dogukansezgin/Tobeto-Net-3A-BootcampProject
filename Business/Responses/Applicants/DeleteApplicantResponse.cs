namespace Business.Responses.Applicants;

public class DeleteApplicantResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
