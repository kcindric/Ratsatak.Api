using Mapster;
using Ratsatak.Application.Offices.Commands.CreateOffice;
using Ratsatak.Contracts.Offices;

namespace Ratsatak.Api.Common.Mapping;

public class OfficeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOfficeRequest, CreateOfficeCommand>()
            .Map(dest => dest.Id, src => src.Id);
    }
}