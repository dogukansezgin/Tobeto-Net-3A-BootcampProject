namespace Business.Responses.Employees;

public class CreateEmployeeResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Position { get; set; }
    public DateTime CreatedDate { get; set; }
}
