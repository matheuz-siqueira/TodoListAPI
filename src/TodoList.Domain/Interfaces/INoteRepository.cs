using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces;

public interface INoteRepository
{
    Task<Note> RegisterAsync(Note note);
    Task<Note> GetByIdAsync(int userId, int noteId);
}
