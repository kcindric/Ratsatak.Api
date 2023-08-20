using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.Parcels.Entities;

public class ParcelPart : Entity<int>
{
    private ParcelPart(
        int parcelPartId,
        string? name,
        string? area,
        int parcelId,
        int possessionSheetId,
        string? lastChangeLogNumber,
        bool? building,
        DateTime createdDateTime,
        DateTime updatedDateTime) :
        base(parcelPartId)
    {
        Id = parcelPartId;
        Name = name;
        Area = area;
        ParcelId = parcelId;
        PossessionSheetId = possessionSheetId;
        LastChangeLogNumber = lastChangeLogNumber;
        Building = building;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    protected ParcelPart()
    {
    }

    public string? Name { get; private set; }
    public string? Area { get; private set; }
    public int ParcelId { get; private set; }
    public int PossessionSheetId { get; private set; }
    public string? LastChangeLogNumber { get; private set; }
    public bool? Building { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    internal static ParcelPart Create(
        int parcelPartId,
        string? name,
        string? area,
        int parcelId,
        int possessionSheetId,
        string? lastChangeLogNumber,
        bool? building)
    {
        return new ParcelPart(
            parcelPartId,
            name,
            area,
            parcelId,
            possessionSheetId,
            lastChangeLogNumber,
            building,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}