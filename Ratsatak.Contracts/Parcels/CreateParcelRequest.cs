namespace Ratsatak.Contracts.Parcels;

public record CreateParcelRequest(int ParcelId,
    string ParcelNumber,
    int CadMunicipalityId,
    int? InstitutionId,
    string? Address,
    string? Area,
    int? BuildingRemark,
    string? DetailSheetNumber,
    bool? HasBuildingRight,
    string? Properties,
    string? Geometry,
    int? LrUnitId,
    List<ParcelPartRequest> ParcelParts);

public record ParcelPartRequest(int ParcelPartId,
    string? Name,
    string? Area,
    int PossessionSheetId,
    string? LastChangeLogNumber,
    bool? Building);