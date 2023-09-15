namespace TodoList.Application.Exceptions.TodoListExceptions;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException(string message) : base(message)
    { }
}
