namespace Business.Requests.Users;

public class DeleteUserRequest
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
}
