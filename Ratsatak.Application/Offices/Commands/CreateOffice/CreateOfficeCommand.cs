using MediatR;
using Ratsatak.Domain.Offices;

namespace Ratsatak.Application.Offices.Commands.CreateOffice;

public record CreateOfficeCommand(int Id, string Name) : IRequest<Office>;