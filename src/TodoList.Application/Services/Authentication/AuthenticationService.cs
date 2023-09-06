using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TodoList.Application.DTOs.User;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces;


namespace TodoList.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthenticationService(
        IUserRepository repository,
        IConfiguration configuration,
        IMapper mapper)
    {
        _repository = repository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponseJson> Login(AuthenticationRequestJson request)
    {
        var user = await _repository.GetByEmail(request.Email);
        if ((user is null) || (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)))
        {
            throw new IncorretCredentialsException("incorret username or password");
        }

        var tokenJWT = GenerateToken(user);
        var response = new AuthenticationResponseJson
        {
            Name = user.Name,
            Token = tokenJWT
        };

        return response;
    }

    private string GenerateToken(Domain.Models.User user)
    {
        var JWTKey = Encoding.ASCII.GetBytes(_configuration["JWTKey"]);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(JWTKey),
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.Name));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

        var tokenJWT = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials,
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenJWT);
    }
}
