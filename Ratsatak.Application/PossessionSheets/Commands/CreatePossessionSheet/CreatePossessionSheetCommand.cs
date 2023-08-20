using MediatR;
using Ratsatak.Application.Common.CommandQueryInterfaces;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Application.PossessionSheets.Commands.CreatePossessionSheet;

public record CreatePossessionSheetCommand(
    int Id,
    string? PossessionSheetNumber,
    int? TypeId,
    int MunicipalityId,
    byte[]? File,
    string? FileName,
    string? FilePath,
    bool? IsHarmonized,
    List<PossessorsCommand> Possessors) : IRequest<PossessionSheet>, IFileCommand;

public record PossessorsCommand(
    string? Name,
    string? Ownership,
    string? Address);