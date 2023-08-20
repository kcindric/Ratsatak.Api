using MediatR;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Application.Municipalities.Commands.CreateMunicipality;

public record CreateMunicipalityCommand(int Id,
    string Name,
    int RegNum,
    int DepartmentId,
    string DisplayName) : IRequest<Municipality>;