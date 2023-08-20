using MediatR;
using Ratsatak.Domain.Parcels;

namespace Ratsatak.Application.Parcels.Commands.CreateParcel;

public record CreateParcelCommand(int Id,
    string? Geometry,
    string ParcelNumber,
    string? Properties,
    int? InstitutionId,
    string? Address,
    string? Area,
    int? BuildingRemark,
    string? DetailSheetNumber,
    bool? HasBuildingRight,
    int MunicipalityId,
    int? LrUnitId,
    List<ParcelPartCommand> ParcelParts) : IRequest<Parcel>;

public record ParcelPartCommand(int Id,
    string? Name,
    string? Area,
    string? LastChangeLogNumber,
    bool? Building,
    int PossessionSheetId);