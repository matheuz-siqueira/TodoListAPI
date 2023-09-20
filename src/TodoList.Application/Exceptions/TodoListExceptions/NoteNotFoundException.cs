namespace TodoList.Application.Exceptions.TodoListExceptions;

public class NoteNotFoundException : Exception
{
    public NoteNotFoundException(string message) : base(message)
    { }
}
