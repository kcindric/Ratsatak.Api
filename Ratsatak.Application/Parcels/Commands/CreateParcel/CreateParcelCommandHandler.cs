using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Parcels;

namespace Ratsatak.Application.Parcels.Commands.CreateParcel;

public class CreateParcelCommandHandler : IRequestHandler<CreateParcelCommand, Parcel>
{
    private readonly IMunicipalityRepository _municipalityRepository;
    private readonly IParcelRepository _parcelRepository;

    public CreateParcelCommandHandler(IParcelRepository parcelRepository,
        IMunicipalityRepository municipalityRepository)
    {
        _parcelRepository = parcelRepository;
        _municipalityRepository = municipalityRepository;
    }

    public async Task<Parcel> Handle(CreateParcelCommand request, CancellationToken cancellationToken)
    {
        var existingParcel = await _parcelRepository.GetParcelById(request.Id);

        if (existingParcel is not null)
            throw new RecordAlreadyExistsException($"Parcel with id '{request.Id}' already exists!");
        
        var parcel = Parcel.Create(request.Id,
            request.Geometry,
            request.MunicipalityId,
            request.ParcelNumber,
            request.Address,
            request.Area,
            request.DetailSheetNumber,
            request.Properties,
            request.InstitutionId,
            request.BuildingRemark,
            request.HasBuildingRight,
            request.LrUnitId);

        request.ParcelParts.ForEach(parcelPart =>
        {
            parcel.CreateAndAddParcelPart(parcelPart.Id,
                parcelPart.Name,
                parcelPart.Area,
                parcelPart.PossessionSheetId,
                parcelPart.LastChangeLogNumber,
                parcelPart.Building);
        });

        await _parcelRepository.AddParcel(parcel);

        return parcel;
    }
}