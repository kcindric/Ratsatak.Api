using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratsatak.Api.Controllers.Base;
using Ratsatak.Application.Offices.Commands.CreateOffice;
using Ratsatak.Contracts.Offices;
using Ratsatak.Domain.Offices;

namespace Ratsatak.Api.Controllers;

[Route("offices")]
public class OfficeController : BaseController
{
    public OfficeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateOffice([FromBody] CreateOfficeRequest request)
    {
        var command = _mapper.Map<CreateOfficeCommand>(request);
        var createOfficeResult = await _mediator.Send(command);

        return Ok(createOfficeResult);
    }

    [HttpPost("create-offices")]
    public async Task<IActionResult> CreateOffices([FromBody] List<CreateOfficeRequest> request)
    {
        List<Office?> createdOffices = new();

        foreach (var officeRequest in request)
        {
            var command = _mapper.Map<CreateOfficeCommand>(officeRequest);
            var createOfficeResult = await _mediator.Send(command);

            createdOffices.Add(createOfficeResult);
        }

        return Ok(createdOffices);
    }
}