using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratsatak.Api.Controllers.Base;
using Ratsatak.Application.LandRegistryUnits.Commands.CreateLandRegistryUnit;
using Ratsatak.Application.LandRegistryUnits.Queries.GetLandRegistryUnit;
using Ratsatak.Contracts.LandRegistryUnit;

namespace Ratsatak.Api.Controllers;

[Route("land-registry")]
public class LandRegistryUnitController : BaseController
{
    public LandRegistryUnitController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    
    [HttpGet("{landRegistryUnitId}")]
    public async Task<IActionResult> GetLandRegistryUnit(int landRegistryUnitId)
    {
        var query = new GetLandRegistryUnitQuery(landRegistryUnitId);

        var getLandRegistryUnitResult = await _mediator.Send(query);

        return Ok(getLandRegistryUnitResult);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLandRegistryUnit(
        [FromBody]CreateLandRegistryUnitRequest request)
    {
        var command = _mapper.Map<CreateLandRegistryUnitCommand>(request);
        var createLandRegistryUnitResult = await _mediator.Send(command);

        return Ok(createLandRegistryUnitResult);
    }
}