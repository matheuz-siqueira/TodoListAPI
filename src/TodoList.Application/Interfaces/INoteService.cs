using TodoList.Application.DTOs.Note;

namespace TodoList.Application.Interfaces;

public interface INoteService
{
    Task<RegisterNoteResponseJson> RegisterAsync(RegisterNoteRequestJson request);
    Task<GetNoteResponseJson> GetByIdAsync(string noteId);
    Task<IList<GetNoteResponseJson>> GetAllAsync();
    Task RemoveAsync(string id);
}
