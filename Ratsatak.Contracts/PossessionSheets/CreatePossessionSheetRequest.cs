namespace Ratsatak.Contracts.PossessionSheets;

public record CreatePossessionSheetRequest(int Id,
    string? PossessionSheetNumber,
    int CadMunicipalityId,
    int? PossessionSheetTypeId,
    byte[]? File,
    string? FileName,
    string? FilePath,
    bool? IsHarmonized,
    List<PossessorsRequest> Possessors);

public record PossessorsRequest(string? Name,
    string? Ownership,
    string? Address);