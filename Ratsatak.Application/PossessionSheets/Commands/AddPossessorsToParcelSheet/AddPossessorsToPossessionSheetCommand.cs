using MediatR;
using Ratsatak.Application.PossessionSheets.Commands.CreatePossessionSheet;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Application.PossessionSheets.Commands.AddPossessorsToParcelSheet;

public record AddPossessorsToPossessionSheetCommand(
    int Id,
    List<PossessorsCommand> Possessors) : IRequest<PossessionSheet?>;