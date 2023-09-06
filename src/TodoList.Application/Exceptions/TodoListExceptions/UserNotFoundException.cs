namespace TodoList.Application.Exceptions.TodoListExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    { }
}
