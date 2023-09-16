namespace TodoList.Application.Exceptions.TodoListExceptions;

public class InvalidIDException : Exception
{
    public InvalidIDException(string message) : base(message)
    { }
}
