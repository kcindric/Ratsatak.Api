using Ratsatak.Domain.Parcels;

namespace Ratsatak.Application.Persistence.Repositories;

public interface IParcelRepository
{
    Task AddParcel(Parcel parcel);
    Task<Parcel?> GetParcelById(int id);
}