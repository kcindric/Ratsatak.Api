using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratsatak.Api.Controllers.Base;
using Ratsatak.Application.Municipalities.Commands.CreateMunicipality;
using Ratsatak.Application.Municipalities.Commands.SetMunicipalityScrapedStatus;
using Ratsatak.Application.Municipalities.Queries.GetNextUnscrapedMunicipality;
using Ratsatak.Contracts.Municipalities;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Api.Controllers;

[Route("municipalities")]
public class MunicipalityController : BaseController
{
    public MunicipalityController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateMunicipality([FromBody] CreateMunicipalityRequest request)
    {
        var command = _mapper.Map<CreateMunicipalityCommand>(request);
        var createMunicipalityResult = await _mediator.Send(command);

        return Ok(createMunicipalityResult);
    }

    [HttpPost("create-municipalities")]
    public async Task<IActionResult> CreateMunicipalities([FromBody] List<CreateMunicipalityRequest> request)
    {
        List<Municipality?> createdMunicipalities = new();

        foreach (var municipalityRequest in request)
        {
            var command = _mapper.Map<CreateMunicipalityCommand>(municipalityRequest);
            var createMunicipalityResult = await _mediator.Send(command);

            createdMunicipalities.Add(createMunicipalityResult);
        }

        return Ok(createdMunicipalities);
    }


    [HttpGet]
    public async Task<IActionResult> GetNextUnscrapedMunicipality()
    {
        var query = new GetNextUnscrapedMunicipalityQuery();
        var getNextUnscrapedMunicipalityResult = await _mediator.Send(query);

        return Ok(getNextUnscrapedMunicipalityResult);
    }

    [HttpPost("set-scraped")]
    public async Task<IActionResult> SetMunicipalityScrapedStatus(
        [FromBody] SetMunicipalityScrapedStatusRequest request)
    {
        var command = _mapper.Map<SetMunicipalityScrapedStatusCommand>(request);
        await _mediator.Send(command);

        return NoContent();
    }
}