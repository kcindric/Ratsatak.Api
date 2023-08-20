using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Application.Persistence.Repositories;

public interface IPossessionSheetRepository
{
    Task AddPossessionSheet(PossessionSheet possessionSheet);
    Task UpdatePossessionSheet(PossessionSheet possessionSheet);
    Task<PossessionSheet?> GetPossessionSheetById(int id);
}