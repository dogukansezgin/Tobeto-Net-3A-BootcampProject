namespace Business.Requests.Blacklists;

public class UpdateBlacklistRequest
{
    public int Id { get; set; }
    public Guid? ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime? Date { get; set; }
}
