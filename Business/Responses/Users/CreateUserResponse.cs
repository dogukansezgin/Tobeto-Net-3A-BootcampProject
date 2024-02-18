namespace Business.Responses.Users;

public class CreateUserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}
