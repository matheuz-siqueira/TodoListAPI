namespace TodoList.Application.Exceptions.TodoListExceptions;

public class DifferentPasswordsException : Exception
{
    public DifferentPasswordsException(string message) : base(message)
    { }
}
