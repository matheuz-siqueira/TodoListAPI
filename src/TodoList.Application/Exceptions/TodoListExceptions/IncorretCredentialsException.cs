namespace TodoList.Application.Exceptions.TodoListExceptions;
public class IncorretCredentialsException : Exception
{
    public IncorretCredentialsException(string message) : base(message)
    { }

}
