using MediatR;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Application.PossessionSheets.Queries.GetPossessionSheet;

public record GetPossessionSheetQuery(int Id) : IRequest<PossessionSheet?>;