using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ratsatak.Api.Controllers.Base;
using Ratsatak.Application.Departments.Commands.CreateDepartment;
using Ratsatak.Contracts.Departments;
using Ratsatak.Domain.Departments;

namespace Ratsatak.Api.Controllers;

[Route("departments")]
public class DepartmentController : BaseController
{
    public DepartmentController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        var command = _mapper.Map<CreateDepartmentCommand>(request);
        var createDepartmentResult = await _mediator.Send(command);

        return Ok(createDepartmentResult);
    }

    [HttpPost("create-departments")]
    public async Task<IActionResult> CreateDepartments([FromBody] List<CreateDepartmentRequest> request)
    {
        List<Department?> createdDepartments = new();

        foreach (var departmentRequest in request)
        {
            var command = _mapper.Map<CreateDepartmentCommand>(departmentRequest);
            var createDepartmentResult = await _mediator.Send(command);

            createdDepartments.Add(createDepartmentResult);
        }

        return Ok(createdDepartments);
    }
}