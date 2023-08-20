using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ratsatak.Api.Controllers.Base;
using Ratsatak.Application.PossessionSheets.Commands.AddPossessorsToParcelSheet;
using Ratsatak.Application.PossessionSheets.Commands.CreatePossessionSheet;
using Ratsatak.Application.PossessionSheets.Queries.GetPossessionSheet;
using Ratsatak.Contracts.PossessionSheets;

namespace Ratsatak.Api.Controllers;

[Route("possession-sheets")]
public class PossessionSheetController : BaseController
{
    public PossessionSheetController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreatePossessionSheet([FromBody] CreatePossessionSheetRequest request)
    {
        var command = _mapper.Map<CreatePossessionSheetCommand>(request);
        var createPossessionSheetResult = await _mediator.Send(command);

        return Ok(createPossessionSheetResult);
    }

    [HttpGet("{possessionSheetId}")]
    public async Task<IActionResult> GetPossessionSheet(int possessionSheetId)
    {
        var query = new GetPossessionSheetQuery(possessionSheetId);

        var getPossessionSheetResult = await _mediator.Send(query);

        return Ok(getPossessionSheetResult);
    }

    [HttpPost("add-possessors")]
    public async Task<IActionResult> AddPossessorsToPossessionSheet(
        [FromBody] AddPossessorsToPossessionSheetRequest request)
    {
        var command = _mapper.Map<AddPossessorsToPossessionSheetCommand>(request);
        var updatedPossessionSheetResult = await _mediator.Send(command);

        return Ok(updatedPossessionSheetResult);
    }
}