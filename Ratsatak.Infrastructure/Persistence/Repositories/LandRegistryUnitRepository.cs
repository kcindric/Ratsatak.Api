using Microsoft.EntityFrameworkCore;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.LandRegistryUnits;
using Ratsatak.Infrastructure.Persistence.DbContexts;

namespace Ratsatak.Infrastructure.Persistence.Repositories;

public class LandRegistryUnitRepository : ILandRegistryUnitRepository
{
    private readonly RatsatakDbContext _dbContext;

    public LandRegistryUnitRepository(RatsatakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddLandRegistryUnit(LandRegistryUnit landRegistryUnit)
    {
        await _dbContext.AddAsync(landRegistryUnit);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateLandRegistryUnit(LandRegistryUnit landRegistryUnit)
    {
        _dbContext.Update(landRegistryUnit);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<LandRegistryUnit?> GetLandRegistryUnitById(int id)
    {
        return await _dbContext.LandRegistryUnits.FirstOrDefaultAsync(x => x.Id == id);
    }
}