namespace TodoList.Application.Exceptions.TodoListExceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message) : base(message)
    { }
}
