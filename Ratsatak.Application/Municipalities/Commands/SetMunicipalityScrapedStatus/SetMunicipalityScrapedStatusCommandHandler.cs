using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;

namespace Ratsatak.Application.Municipalities.Commands.SetMunicipalityScrapedStatus;

public class SetMunicipalityScrapedStatusCommandHandler :
    IRequestHandler<SetMunicipalityScrapedStatusCommand>
{
    private readonly IMunicipalityRepository _municipalityRepository;

    public SetMunicipalityScrapedStatusCommandHandler(IMunicipalityRepository municipalityRepository)
    {
        _municipalityRepository = municipalityRepository;
    }

    public async Task Handle(SetMunicipalityScrapedStatusCommand request, CancellationToken cancellationToken)
    {
        var municipality = await _municipalityRepository.GetMunicipalityById(request.Id);
        if (municipality is null)
            throw new RecordDoesNotExistException($"Can't find municipality with id = {request.Id}");

        municipality.UpdateMunicipalityScrapedStatus(request.Scraped);
        
        await _municipalityRepository.UpdateMunicipality(municipality);
    }
}