using Microsoft.EntityFrameworkCore;
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

        public Task<Domain.Models.User> GetByEmail(string email)
        {
            return _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Domain.Models.User> GetById(int id)
        {
            return await _context.Users.FirstAsync(u => u.Id == id);
        }

        public Task<Domain.Models.User> GetProfileAsync(int id)
        {
            return _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async System.Threading.Tasks.Task RegisterAsync(Domain.Models.User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdatePasswordAsync(Domain.Models.User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}