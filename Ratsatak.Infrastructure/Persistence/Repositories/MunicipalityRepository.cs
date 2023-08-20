using Microsoft.EntityFrameworkCore;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Municipalities;
using Ratsatak.Infrastructure.Persistence.DbContexts;

namespace Ratsatak.Infrastructure.Persistence.Repositories;

public class MunicipalityRepository : IMunicipalityRepository
{
    private readonly RatsatakDbContext _dbContext;

    public MunicipalityRepository(RatsatakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddMunicipality(Municipality municipality)
    {
        await _dbContext.AddAsync(municipality);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMunicipality(Municipality municipality)
    { 
        _dbContext.Update(municipality);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Municipality?> GetMunicipalityById(int id)
    {
        return await _dbContext.Municipalities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Municipality?> GetNextUnscrapedMunicipality()
    {
        return await _dbContext.Municipalities.FirstOrDefaultAsync(x => x.Scraped == false);
    }
}