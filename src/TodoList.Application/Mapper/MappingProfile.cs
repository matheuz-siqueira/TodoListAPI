using AutoMapper;
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
    }

    public void EntityToResponse()
    {
        CreateMap<User, GetProfileResponseJson>();
    }

    public void EntityToRequest()
    {
        CreateMap<User, AuthenticationRequestJson>();
    }
}
