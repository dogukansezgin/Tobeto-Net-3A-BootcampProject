namespace Business.Responses.Bootcamps;

public class DeleteBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? DeletedDate { get; set; }
}
