using AutoMapper;
using TodoList.Application.DTOs.Task;
using TodoList.Application.DTOs.User;
using TodoList.Domain.Models;

namespace TodoList.Application.Mapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
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
    }

    public void EntityToResponse()
    {
        CreateMap<User, GetProfileResponseJson>();
        CreateMap<Domain.Models.Task, RegisterTaskResponseJson>();
        CreateMap<Domain.Models.SubTask, RegisterSubTaskResponseJson>();
        CreateMap<Domain.Models.Task, GetAllTaskResponseJson>();
        CreateMap<Domain.Models.Task, GetTaskResponseJson>();
        CreateMap<Domain.Models.SubTask, GetSubTasksResponseJson>();
    }

    public void EntityToRequest()
    {
        CreateMap<User, AuthenticationRequestJson>();
    }
}
