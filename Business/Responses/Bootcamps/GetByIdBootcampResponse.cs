namespace Business.Responses.Bootcamps;

public class GetByIdBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public string InstructorUserName { get; set; }
    public int BootcampStateId { get; set; }
    public string BootcampStateName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
