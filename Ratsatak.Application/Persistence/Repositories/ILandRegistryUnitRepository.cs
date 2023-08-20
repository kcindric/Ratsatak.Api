using Ratsatak.Domain.LandRegistryUnits;

namespace Ratsatak.Application.Persistence.Repositories;

public interface ILandRegistryUnitRepository
{
    Task AddLandRegistryUnit(LandRegistryUnit landRegistryUnit);
    Task UpdateLandRegistryUnit(LandRegistryUnit landRegistryUnit);
    Task<LandRegistryUnit?> GetLandRegistryUnitById(int id);
}