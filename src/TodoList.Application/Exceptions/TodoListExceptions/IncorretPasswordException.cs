namespace TodoList.Application.Exceptions.TodoListExceptions;

public class IncorretPasswordException : Exception
{
    public IncorretPasswordException(string message) : base(message)
    { }
}
