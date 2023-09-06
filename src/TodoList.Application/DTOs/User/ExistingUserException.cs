namespace TodoList.Application.DTOs.User;

public class ExistingUserException : Exception
{
    public ExistingUserException(string message) : base(message)
    { }
}
