namespace Business.Responses.Applications;

public class UpdateApplicationResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
