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
        private readonly IAuthenticationService _auth;
        private readonly IUserLogged _logged;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper,
            IAuthenticationService auth, IUserLogged logged)
        {
            _repository = repository;
            _mapper = mapper;
            _auth = auth;
            _logged = logged;
        }

        public async Task<GetProfileResponseJson> GetProfileAsync()
        {
            var userId = _logged.GetCurrentUserId();
            var user = await _repository.GetProfileAsync(userId);
            if (user is null)
            {
                throw new UserNotFoundException("user not found");
            }

            var response = _mapper.Map<GetProfileResponseJson>(user);
            return response;
        }

        public async Task<AuthenticationResponseJson> RegisterAsync(RegisterUserRequestJson request)
        {
            var existing = await _repository.GetByEmail(request.Email);
            if (existing is not null)
            {
                throw new ExistingUserException("user already exists");
            }
            if (request.Password != request.ConfirmPassword)
            {
                throw new DifferentPasswordsException("different passwords");
            }


            var user = _mapper.Map<TodoList.Domain.Models.User>(request);
            var login = _mapper.Map<AuthenticationRequestJson>(user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            await _repository.RegisterAsync(user);
            return await _auth.Login(login);

        }
    }
}