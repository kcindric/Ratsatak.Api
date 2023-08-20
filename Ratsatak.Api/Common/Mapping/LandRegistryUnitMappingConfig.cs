using Mapster;
using Ratsatak.Application.LandRegistryUnits.Commands.CreateLandRegistryUnit;
using Ratsatak.Contracts.LandRegistryUnit;

namespace Ratsatak.Api.Common.Mapping;

public class LandRegistryUnitMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateLandRegistryUnitRequest, CreateLandRegistryUnitCommand>()
            .Map(dest => dest.LandRegistryUnitNumber, src => src.LrUnitNumber);
    }
}