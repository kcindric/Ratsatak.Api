using MediatR;

namespace Ratsatak.Application.Municipalities.Commands.SetMunicipalityScrapedStatus;

public record SetMunicipalityScrapedStatusCommand(
    int Id,
    bool Scraped
) : IRequest;