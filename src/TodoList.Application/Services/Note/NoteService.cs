using AutoMapper;
using TodoList.Application.DTOs.Note;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Repositories.Note;

namespace TodoList.Application.Services.Note;

public class NoteService : INoteService
{
    private readonly INoteRepository _repository;
    private readonly IUserLogged _logged;
    private readonly IMapper _mapper;
    public NoteService(INoteRepository repository, IUserLogged logged, IMapper mapper)
    {
        _repository = repository;
        _logged = logged;
        _mapper = mapper;
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
}
