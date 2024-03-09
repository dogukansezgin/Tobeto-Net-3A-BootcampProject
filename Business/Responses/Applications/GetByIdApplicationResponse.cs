namespace Business.Responses.Applications;

public class GetByIdApplicationResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string ApplicantUserName { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string About { get; set; }
    public DateTime ApplicantDateOfBirth { get; set; }
    public string ApplicantNationalIdentity { get; set; }
    public string ApplicantEmail { get; set; }
    public DateTime ApplicantCreatedDate { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public int BootcampInstructorId { get; set; }
    public int BootcampBootcampStateId { get; set; }
    public DateTime BootcampStartDate { get; set; }
    public DateTime BootcampEndDate { get; set; }
    public DateTime BootcampCreatedDate { get; set; }
    public int ApplicationStateId { get; set; }
    public string ApplicationStateName { get; set; }
    public DateTime ApplicationStateCreatedDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
