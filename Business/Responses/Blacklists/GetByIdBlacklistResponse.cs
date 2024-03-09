namespace Business.Responses.Blacklists;

public class GetByIdBlacklistResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string ApplicantUserName { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string ApplicantAbout { get; set; }
    public DateTime ApplicantDateOfBirth { get; set; }
    public string ApplicantNationalIdentity { get; set; }
    public string ApplicantEmail { get; set; }
    public DateTime ApplicantCreatedDate { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
