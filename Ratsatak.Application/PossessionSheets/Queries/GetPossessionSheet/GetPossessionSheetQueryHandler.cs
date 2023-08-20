using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Application.PossessionSheets.Queries.GetPossessionSheet;

public class GetPossessionSheetQueryHandler : IRequestHandler<GetPossessionSheetQuery, PossessionSheet?>
{
    private readonly IPossessionSheetRepository _possessionSheetRepository;

    public GetPossessionSheetQueryHandler(IPossessionSheetRepository possessionSheetRepository)
    {
        _possessionSheetRepository = possessionSheetRepository;
    }

    public async Task<PossessionSheet?> Handle(GetPossessionSheetQuery request, CancellationToken cancellationToken)
    {
        var possessionSheet =
            await _possessionSheetRepository.GetPossessionSheetById(request.Id);

        if (possessionSheet is null)
            throw new RecordDoesNotExistException($"Can't find possession sheet with id = {request.Id}");

        return possessionSheet;
    }
}