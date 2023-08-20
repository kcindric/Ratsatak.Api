using MediatR;
using Ratsatak.Domain.LandRegistryUnits;

namespace Ratsatak.Application.LandRegistryUnits.Queries.GetLandRegistryUnit;

public record GetLandRegistryUnitQuery(int LandRegistryUnitId) : IRequest<LandRegistryUnit>;