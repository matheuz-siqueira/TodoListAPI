using TodoList.Domain.Interfaces;
using TodoList.Infra.Data;

namespace TodoList.Infra.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task RegisterAsync(Domain.Models.User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}