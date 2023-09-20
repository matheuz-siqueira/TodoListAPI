using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data;

namespace TodoList.Infra.Repositories.Note;

public class NoteRepository : INoteRepository
{
    private readonly Context _context;
    public NoteRepository(Context context)
    {
        _context = context;
    }

    public Task<Domain.Models.Note> GetByIdAsync(int userId, int noteId)
    {
        return _context.Notes.AsNoTracking()
            .Where(note => note.UserId == userId)
            .FirstOrDefaultAsync(note => note.Id == noteId);
    }

    public async Task<Domain.Models.Note> RegisterAsync(Domain.Models.Note note)
    {
        await _context.Notes.AddAsync(note);
        await _context.SaveChangesAsync();
        return note;
    }
}
