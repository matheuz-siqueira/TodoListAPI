using AutoMapper;
using TodoList.Application.DTOs.Note;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Repositories.Note;

namespace TodoList.Application.Services.Note;

public class NoteService : INoteService
{
    private readonly INoteRepository _repository;
    private readonly IUserLogged _logged;
    private readonly IMapper _mapper;
    private readonly IHashidsService _hashids;
    public NoteService(INoteRepository repository,
        IUserLogged logged,
        IMapper mapper,
        IHashidsService hashids)
    {
        _repository = repository;
        _logged = logged;
        _mapper = mapper;
        _hashids = hashids;
    }

    public async Task<IList<GetNoteResponseJson>> GetAllAsync()
    {
        var userId = _logged.GetCurrentUserId();
        var notes = await _repository.GetAllAsync(userId);
        var response = _mapper.Map<IList<GetNoteResponseJson>>(notes);
        return response;
    }

    public async Task<GetNoteResponseJson> GetByIdAsync(string noteId)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(noteId);
        var id = _hashids.Decode(noteId);
        var note = await _repository.GetByIdAsync(userId, id);
        if (note is null)
        {
            throw new NoteNotFoundException("note not found");
        }
        var response = _mapper.Map<GetNoteResponseJson>(note);
        return response;
    }

    public async Task<RegisterNoteResponseJson> RegisterAsync(RegisterNoteRequestJson request)
    {
        var userId = _logged.GetCurrentUserId();
        var note = _mapper.Map<TodoList.Domain.Models.Note>(request);
        note.UserId = userId;
        await _repository.RegisterAsync(note);
        var response = _mapper.Map<RegisterNoteResponseJson>(note);
        return response;

    }

    public async System.Threading.Tasks.Task RemoveAllAsync()
    {
        var userId = _logged.GetCurrentUserId(); 
        var annotations = _repository.GetAllAsync(userId).Result; 
        if(annotations.Any())
        {
            await _repository.RemoveAllAsync(annotations); 
        } 
    }

    public async System.Threading.Tasks.Task RemoveAsync(string id)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(id);
        var noteId = _hashids.Decode(id);
        var note = await _repository.GetByIdAsync(userId, noteId);
        if (note is null)
        {
            throw new NoteNotFoundException("note not found");
        }
        await _repository.RemoveAsync(note);
    }

    public async System.Threading.Tasks.Task UpdateAsync(string id, UpdateNoteRequestJson request)
    {
        var userId = _logged.GetCurrentUserId();
        _hashids.IsHash(id);
        var noteId = _hashids.Decode(id);
        var note = await _repository.GetByIdTracking(userId, noteId);
        if (note is null)
        {
            throw new NoteNotFoundException("note not found");
        }
        _mapper.Map(request, note);
        await _repository.UpdateAsync();
    }
}
