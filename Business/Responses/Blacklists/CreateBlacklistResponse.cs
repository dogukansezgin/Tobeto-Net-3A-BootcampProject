namespace Business.Responses.Blacklists;

public class CreateBlacklistResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedDate { get; set; }
}
