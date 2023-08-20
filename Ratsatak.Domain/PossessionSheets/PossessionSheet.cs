using Ratsatak.Domain.Common.Models;
using Ratsatak.Domain.PossessionSheets.ValueObjects;

namespace Ratsatak.Domain.PossessionSheets;

public class PossessionSheet : AggregateRoot<int>
{
    private readonly List<Possessor> _possessors = new();

    private PossessionSheet(
        int possessionSheetId,
        string? possessionSheetNumber,
        int? typeId,
        int municipalityId,
        string? fileName,
        string? filePath,
        bool? isHarmonized,
        DateTime createdDateTime,
        DateTime updatedDateTime) :
        base(possessionSheetId)
    {
        PossessionSheetNumber = possessionSheetNumber;
        TypeId = typeId;
        MunicipalityId = municipalityId;
        FileName = fileName;
        FilePath = filePath;
        IsHarmonized = isHarmonized;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private PossessionSheet()
    {
    }

    public string? PossessionSheetNumber { get; private set; }
    public int? TypeId { get; private set; }
    public int MunicipalityId { get; private set; }
    public string? FileName { get; private set; }
    public string? FilePath { get; private set; }
    public bool? IsHarmonized { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<Possessor> Possessors => _possessors.AsReadOnly();

    public static PossessionSheet Create(
        int possessionSheetId,
        string? possessionSheetNumber,
        int? typeId,
        int municipalityId,
        string? fileName,
        string? filePath,
        bool? isHarmonized)
    {
        return new PossessionSheet(
            possessionSheetId,
            possessionSheetNumber,
            typeId,
            municipalityId,
            fileName,
            filePath,
            isHarmonized,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public Possessor CreateAndAddPossessor(string? name, string? ownership, string? address)
    {
        var possessor = Possessor.Create(name, ownership, address);
        _possessors.Add(possessor);

        return possessor;
    }

    public void AddPossessor(Possessor possessor)
    {
        _possessors.Add(possessor);
    }
}