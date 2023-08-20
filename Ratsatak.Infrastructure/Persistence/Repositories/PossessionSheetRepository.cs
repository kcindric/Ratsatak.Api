using Microsoft.EntityFrameworkCore;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.PossessionSheets;
using Ratsatak.Infrastructure.Persistence.DbContexts;

namespace Ratsatak.Infrastructure.Persistence.Repositories;

public class PossessionSheetRepository : IPossessionSheetRepository
{
    private readonly RatsatakDbContext _dbContext;

    public PossessionSheetRepository(RatsatakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPossessionSheet(PossessionSheet possessionSheet)
    {
        await _dbContext.AddAsync(possessionSheet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePossessionSheet(PossessionSheet possessionSheet)
    {
        _dbContext.Update(possessionSheet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PossessionSheet?> GetPossessionSheetById(int id)
    {
        return await _dbContext.PossessionSheets.FirstOrDefaultAsync(x => x.Id == id);
    }
}