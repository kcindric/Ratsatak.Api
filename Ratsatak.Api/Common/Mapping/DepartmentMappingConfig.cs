using Mapster;
using Ratsatak.Application.Departments.Commands.CreateDepartment;
using Ratsatak.Contracts.Departments;

namespace Ratsatak.Api.Common.Mapping;

public class DepartmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateDepartmentRequest, CreateDepartmentCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OfficeId, src => src.OfficeId);
    }
}