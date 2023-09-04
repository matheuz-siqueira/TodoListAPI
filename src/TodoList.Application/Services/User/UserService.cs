using AutoMapper;
using TodoList.Application.DTOs.User;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LoginResponseJson> RegisterAsync(RegisterUserRequestJson request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new DifferentPasswordsException("different passwords");
            }

            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = _mapper.Map<TodoList.Domain.Models.User>(request);
            await _repository.RegisterAsync(user);

            return new LoginResponseJson
            {
                Name = request.Name,
                Token = "Token"
            };


        }
    }
}