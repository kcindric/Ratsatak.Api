using MediatR;
using Ratsatak.Application.Common.CommandQueryInterfaces;
using Ratsatak.Domain.LandRegistryUnits;

namespace Ratsatak.Application.LandRegistryUnits.Commands.CreateLandRegistryUnit;

public record CreateLandRegistryUnitCommand(
    int Id,
    string? LandRegistryUnitNumber,
    int MunicipalityId,
    string? Status,
    bool? Verificated,
    bool? Condominiums,
    int? MainBookId,
    byte[]? File,
    string? FileName,
    string? FilePath) : IRequest<LandRegistryUnit>, IFileCommand;
