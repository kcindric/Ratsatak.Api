using Microsoft.EntityFrameworkCore;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Offices;
using Ratsatak.Infrastructure.Persistence.DbContexts;

namespace Ratsatak.Infrastructure.Persistence.Repositories;

public class OfficeRepository : IOfficeRepository
{
    private readonly RatsatakDbContext _dbContext;

    public OfficeRepository(RatsatakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddOffice(Office office)
    {
        await _dbContext.AddAsync(office);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Office?> GetOfficeById(int id)
    {
        return await _dbContext.Offices.FirstOrDefaultAsync(x => x.Id == id);
    }
}