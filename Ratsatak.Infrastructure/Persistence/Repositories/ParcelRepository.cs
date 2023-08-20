using Microsoft.EntityFrameworkCore;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Parcels;
using Ratsatak.Infrastructure.Persistence.DbContexts;

namespace Ratsatak.Infrastructure.Persistence.Repositories;

public class ParcelRepository : IParcelRepository
{
    private readonly RatsatakDbContext _dbContext;

    public ParcelRepository(RatsatakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddParcel(Parcel parcel)
    {
        await _dbContext.AddAsync(parcel);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Parcel?> GetParcelById(int id)
    {
        return await _dbContext.Parcels.FirstOrDefaultAsync(x => x.Id == id);
    }
}