namespace Business.Responses.Bootcamps;

public class GetByIdBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public string InstructorUserName { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string InstructorCompanyName { get; set; }
    public DateTime InstructorDateOfBirth { get; set; }
    public string InstructorNationalIdentity { get; set; }
    public string InstructorEmail { get; set; }
    public DateTime InstructorCreatedDate { get; set; }
    public int BootcampStateId { get; set; }
    public string BootcampStateName { get; set; }
    public DateTime BootcampStateCreatedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
