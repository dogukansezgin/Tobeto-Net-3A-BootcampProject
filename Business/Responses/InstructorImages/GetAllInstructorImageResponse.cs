namespace Business.Responses.InstructorImages;

public class GetAllInstructorImageResponse
{
    public Guid Id { get; set; }
    public int InstructorId { get; set; }
    public string InstructorUserName { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string InstructorCompanyName { get; set; }
    public DateTime InstructorDateOfBirth { get; set; }
    public string InstructorNationalIdentity { get; set; }
    public string InstructorEmail { get; set; }
    public DateTime InstructorCreatedDate { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
