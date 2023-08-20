namespace Ratsatak.Contracts.LandRegistryUnit;

public record CreateLandRegistryUnitRequest(
    int Id,
    int MunicipalityId,
    string? LrUnitNumber,
    int? MainBookId,
    string? Status,
    bool? Verificated,
    bool? Condominiums,
    byte[]? File,
    string? FileName,
    string? FilePath);