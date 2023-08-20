namespace Ratsatak.Contracts.PossessionSheets;

public record AddPossessorsToPossessionSheetRequest(
    int Id,
    List<PossessorsRequest> Possessors);