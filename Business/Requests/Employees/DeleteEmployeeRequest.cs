namespace Business.Requests.Employees;

public class DeleteEmployeeRequest
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
}
