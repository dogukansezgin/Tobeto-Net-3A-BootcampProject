namespace Business.Responses.ApplicationStates;

public class DeleteApplicationStateResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
