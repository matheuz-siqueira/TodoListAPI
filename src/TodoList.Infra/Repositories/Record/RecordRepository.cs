using Microsoft.EntityFrameworkCore;

using TodoList.Domain.Interfaces;
using TodoList.Infra.Data;

namespace TodoList.Infra.Repositories.Record;

public class RecordRepository : IRecordRepository
{
    private readonly Context _context;
    public RecordRepository(Context context)
    {
        _context = context;
    }

    public async Task<Domain.Models.Record> GetByDateAsync(DateOnly date, int userId)
    {
        return await _context.Records.Where(r => r.UserId == userId)
            .Include(r => r.Tasks)
            .FirstOrDefaultAsync(r => r.Date == date);
    }

    public async System.Threading.Tasks.Task RegisterAsync(Domain.Models.Record record)
    {
        await _context.Records.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveAsync(Domain.Models.Record record)
    {
        _context.Records.Remove(record);
        await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }
}
