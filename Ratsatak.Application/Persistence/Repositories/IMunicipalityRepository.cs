using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Application.Persistence.Repositories;

public interface IMunicipalityRepository
{
    Task AddMunicipality(Municipality municipality);
    Task UpdateMunicipality(Municipality municipality);
    Task<Municipality?> GetMunicipalityById(int id);
    Task<Municipality?> GetNextUnscrapedMunicipality();
}