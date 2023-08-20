using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ratsatak.Api.Controllers.Base;

public abstract class BaseController : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}