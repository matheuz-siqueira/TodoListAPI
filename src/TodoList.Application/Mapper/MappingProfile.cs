using AutoMapper;
using HashidsNet;
using TodoList.Application.DTOs.Note;
using TodoList.Application.DTOs.Task;
using TodoList.Application.DTOs.User;
using TodoList.Domain.Models;

namespace TodoList.Application.Mapper;
public class MappingProfile : Profile
{
    private readonly IHashids _hashids;
    public MappingProfile(IHashids hashids)
    {
        _hashids = hashids;
        RequestToEntity();
        EntityToResponse();
        EntityToRequest();
    }

    public void RequestToEntity()
    {
        CreateMap<RegisterUserRequestJson, User>();
        CreateMap<AuthenticationRequestJson, User>();
        CreateMap<RegisterTaskRequestJson, Domain.Models.Task>();
        CreateMap<RegisterSubTaskRequestJson, Domain.Models.SubTask>();
        CreateMap<GetAllTasksRequestJson, Domain.Models.Task>();
        CreateMap<UpdateTaskRequestJson, Domain.Models.Task>();
        CreateMap<UpdateSubTaskRequestJson, Domain.Models.SubTask>();
        CreateMap<RegisterNoteRequestJson, Domain.Models.Note>();
    }

    public void EntityToResponse()
    {
        CreateMap<User, GetProfileResponseJson>();
        CreateMap<Domain.Models.Task, RegisterTaskResponseJson>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(s => _hashids.Encode(s.Id)));

        CreateMap<Domain.Models.SubTask, RegisterSubTaskResponseJson>();

        CreateMap<Domain.Models.Task, GetAllTaskResponseJson>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(s => _hashids.Encode(s.Id)));

        CreateMap<Domain.Models.Task, GetTaskResponseJson>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(s => _hashids.Encode(s.Id)));

        CreateMap<Domain.Models.SubTask, GetSubTasksResponseJson>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(s => _hashids.Encode(s.Id)));

        CreateMap<Domain.Models.Note, RegisterNoteResponseJson>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(s => _hashids.Encode(s.Id)));

        CreateMap<Domain.Models.Note, GetNoteResponseJson>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(s => _hashids.Encode(s.Id)));
    }

    public void EntityToRequest()
    {
        CreateMap<User, AuthenticationRequestJson>();
    }
}
