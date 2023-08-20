using Mapster;
using Ratsatak.Application.Municipalities.Commands.CreateMunicipality;
using Ratsatak.Application.Municipalities.Commands.SetMunicipalityScrapedStatus;
using Ratsatak.Contracts.Municipalities;

namespace Ratsatak.Api.Common.Mapping;

public class MunicipalityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMunicipalityRequest, CreateMunicipalityCommand>()
            .Map(dest => dest.Id, src => src.Key1)
            .Map(dest => dest.Name, src => src.Value1)
            .Map(dest => dest.RegNum, src => src.Key2)
            .Map(dest => dest.DepartmentId, src => src.Value3)
            .Map(dest => dest.DisplayName, src => src.DisplayValue1);

        config.NewConfig<SetMunicipalityScrapedStatusRequest, SetMunicipalityScrapedStatusCommand>();
    }
}