namespace Business.Responses.Blacklists;

public class GetByIdBlacklistResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string ApplicantUserName { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
