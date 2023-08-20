using Mapster;
using Ratsatak.Application.Parcels.Commands.CreateParcel;
using Ratsatak.Contracts.Parcels;

namespace Ratsatak.Api.Common.Mapping;

public class ParcelMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateParcelRequest, CreateParcelCommand>()
            .Map(dest => dest.Id, src => src.ParcelId)
            .Map(dest => dest.MunicipalityId, src => src.CadMunicipalityId);

        config.NewConfig<ParcelPartRequest, ParcelPartCommand>()
            .Map(dest => dest.Id, src => src.ParcelPartId);
    }
}