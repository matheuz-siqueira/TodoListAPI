using AutoMapper;
using TodoList.Application.DTOs.User;
using TodoList.Domain.Models;

namespace TodoList.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RequestToEntity();
        }

        public void RequestToEntity()
        {
            CreateMap<RegisterUserRequestJson, User>();
        }

        public void EntityToResponse()
        {
        }
    }
}