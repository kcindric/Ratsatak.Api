using MediatR;
using Ratsatak.Domain.Departments;

namespace Ratsatak.Application.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand(int Id, string Name, int OfficeId) : IRequest<Department>;