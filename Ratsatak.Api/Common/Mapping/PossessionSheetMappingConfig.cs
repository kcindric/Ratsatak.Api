using Mapster;
using Ratsatak.Application.PossessionSheets.Commands.AddPossessorsToParcelSheet;
using Ratsatak.Application.PossessionSheets.Commands.CreatePossessionSheet;
using Ratsatak.Contracts.PossessionSheets;

namespace Ratsatak.Api.Common.Mapping;

public class PossessionSheetMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePossessionSheetRequest, CreatePossessionSheetCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TypeId, src => src.PossessionSheetTypeId)
            .Map(dest => dest.MunicipalityId, src => src.CadMunicipalityId);

        config.NewConfig<AddPossessorsToPossessionSheetRequest, AddPossessorsToPossessionSheetCommand>();
    }
}