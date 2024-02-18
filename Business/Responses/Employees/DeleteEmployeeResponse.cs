namespace Business.Responses.Employees;

public class DeleteEmployeeResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
