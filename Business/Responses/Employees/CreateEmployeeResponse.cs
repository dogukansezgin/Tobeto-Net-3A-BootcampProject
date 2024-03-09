namespace Business.Responses.Employees;

public class CreateEmployeeResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Position { get; set; }
    public DateTime CreatedDate { get; set; }
}
