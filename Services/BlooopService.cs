using Blooopy.Data;
using Blooopy.Models;
using Microsoft.EntityFrameworkCore;

namespace Blooopy.Services;

public class BlooopService : IGenericService<Blooop>
{
    public BlooopContext _dbContext { get; set; }

    public BlooopService(BlooopContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Blooop>?> GetAllAsync() => await _dbContext.Blooops.Include(b => b.Comments).ToListAsync();
    public async Task<Blooop?> GetByIdAsync(int id) => await _dbContext.Blooops.FirstOrDefaultAsync(b => b.Id == id);

    public async Task<int> SaveAsync(Blooop blooop)
    {
        if (await _dbContext.Blooops.FindAsync(blooop.Id) is Blooop existing)
        {
            _dbContext.Entry(existing).CurrentValues.SetValues(blooop);
        }
        else
        {
            _dbContext.Blooops.Add(blooop);
        }

        return await _dbContext.SaveChangesAsync();
    }
   
    public async Task<int> DeleteAsync(Blooop blooop)
    {
        _dbContext.Blooops.Remove(blooop);
        return await _dbContext.SaveChangesAsync();
    }

}