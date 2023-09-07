namespace TodoList.Application.DTOs.User;

public class UpdatePasswordRequestJson
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
