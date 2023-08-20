using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.LandRegistryUnits;

namespace Ratsatak.Application.LandRegistryUnits.Queries.GetLandRegistryUnit;

public class GetLandRegistryUnitQueryHandler : IRequestHandler<GetLandRegistryUnitQuery, LandRegistryUnit>
{
    private readonly ILandRegistryUnitRepository _landRegistryUnitRepository;

    public GetLandRegistryUnitQueryHandler(ILandRegistryUnitRepository landRegistryUnitRepository)
    {
        _landRegistryUnitRepository = landRegistryUnitRepository;
    }

    public async Task<LandRegistryUnit> Handle(GetLandRegistryUnitQuery request, CancellationToken cancellationToken)
    {
        var landRegistryUnit =
            await _landRegistryUnitRepository.GetLandRegistryUnitById(request.LandRegistryUnitId);
        
        if(landRegistryUnit is null)
            throw new RecordDoesNotExistException($"Can't find Land Registry Unit with id = {request.LandRegistryUnitId}");

        return landRegistryUnit;
    }
}