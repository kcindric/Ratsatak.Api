using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratsatak.Api.Controllers.Base;
using Ratsatak.Application.Parcels.Commands.CreateParcel;
using Ratsatak.Contracts.Parcels;

namespace Ratsatak.Api.Controllers;

[Route("parcels")]
public class ParcelController : BaseController
{
    public ParcelController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateParcel([FromBody] CreateParcelRequest request)
    {
        var command = _mapper.Map<CreateParcelCommand>(request);
        var createParcelResult = await _mediator.Send(command);

        return Ok(createParcelResult);
    }
}