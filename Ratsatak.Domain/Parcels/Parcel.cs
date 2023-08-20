using Ratsatak.Domain.Common.DomainEvents;
using Ratsatak.Domain.Common.Models;
using Ratsatak.Domain.Parcels.Entities;

namespace Ratsatak.Domain.Parcels;

// TODO: add parcelLinks and other properties
public class Parcel : AggregateRoot<int>
{
    private readonly List<ParcelPart> _parcelParts = new();

    private Parcel(int parcelId, string? geometry, int municipalityId, string parcelNumber, string? address,
        string? area, string? detailSheetNumber, DateTime createdDateTime, DateTime updatedDateTime, string? properties,
        int? institutionId, int? buildingRemark, bool? hasBuildingRight, int? lrUnitId) : base(parcelId)
    {
        Geometry = geometry;
        MunicipalityId = municipalityId;
        ParcelNumber = parcelNumber;
        Address = address;
        Area = area;
        DetailSheetNumber = detailSheetNumber;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        Properties = properties;
        InstitutionId = institutionId;
        BuildingRemark = buildingRemark;
        HasBuildingRight = hasBuildingRight;
        LrUnitId = lrUnitId;
    }

    private Parcel()
    {
    }

    public string? Geometry { get; private set; }
    public string ParcelNumber { get; private set; }
    public string? Properties { get; private set; }
    public int? InstitutionId { get; private set; } // don't know what this is
    public string? Address { get; private set; }
    public string? Area { get; private set; }
    public int? BuildingRemark { get; private set; }
    public string? DetailSheetNumber { get; private set; }
    public bool? HasBuildingRight { get; private set; }
    public int MunicipalityId { get; private set; }
    public int? LrUnitId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<ParcelPart> ParcelParts => _parcelParts.AsReadOnly();

    public static Parcel Create(int parcelId, string? geometry, int municipalityId, string parcelNumber,
        string? address, string? area, string? detailSheetNumber, string? properties, int? institutionId,
        int? buildingRemark, bool? hasBuildingRight, int? lrUnitId)
    {
        return new Parcel(parcelId,
            geometry,
            municipalityId,
            parcelNumber,
            address,
            area,
            detailSheetNumber,
            DateTime.UtcNow,
            DateTime.UtcNow,
            properties,
            institutionId,
            buildingRemark,
            hasBuildingRight,
            lrUnitId);
    }

    public void CreateAndAddParcelPart(int parcelPartId, string? name, string? area,
        int possessionSheetId, string? lastChangeLogNumber, bool? building)
    {
        var parcelPart = ParcelPart.Create(
            parcelPartId,
            name,
            area,
            Id,
            possessionSheetId,
            lastChangeLogNumber,
            building);
        _parcelParts.Add(parcelPart);

        RaiseDomainEvent(new ParcelPartCreatedDomainEvent(parcelPartId, possessionSheetId));
    }
}