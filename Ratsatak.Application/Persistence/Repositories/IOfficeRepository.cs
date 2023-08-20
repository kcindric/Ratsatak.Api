using Ratsatak.Domain.Offices;

namespace Ratsatak.Application.Persistence.Repositories;

public interface IOfficeRepository
{
    Task AddOffice(Office office);
    Task<Office?> GetOfficeById(int id);
}