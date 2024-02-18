namespace Business.Responses.Users;

public class DeleteUserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
