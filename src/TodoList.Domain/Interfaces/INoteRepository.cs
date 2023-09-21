using TodoList.Domain.Models;

namespace TodoList.Domain.Interfaces;

public interface INoteRepository
{
    Task<Note> RegisterAsync(Note note);
    Task<Note> GetByIdAsync(int userId, int noteId);
    Task<IList<Note>> GetAllAsync(int userId);
    System.Threading.Tasks.Task RemoveAsync(Note note);
    Task<Note> GetByIdTracking(int userId, int noteId);
    System.Threading.Tasks.Task UpdateAsync();

}
