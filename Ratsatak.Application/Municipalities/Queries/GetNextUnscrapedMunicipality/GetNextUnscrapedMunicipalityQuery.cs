using MediatR;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Application.Municipalities.Queries.GetNextUnscrapedMunicipality;

public record GetNextUnscrapedMunicipalityQuery : IRequest<Municipality?>;