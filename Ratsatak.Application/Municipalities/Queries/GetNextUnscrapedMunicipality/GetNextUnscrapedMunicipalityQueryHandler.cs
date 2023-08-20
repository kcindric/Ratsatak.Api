using MediatR;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Application.Municipalities.Queries.GetNextUnscrapedMunicipality;

public class
    GetNextUnscrapedMunicipalityQueryHandler : IRequestHandler<GetNextUnscrapedMunicipalityQuery, Municipality?>
{
    private readonly IMunicipalityRepository _municipalityRepository;

    public GetNextUnscrapedMunicipalityQueryHandler(IMunicipalityRepository municipalityRepository)
    {
        _municipalityRepository = municipalityRepository;
    }

    public async Task<Municipality?> Handle(GetNextUnscrapedMunicipalityQuery request,
        CancellationToken cancellationToken)
    {
        return await _municipalityRepository.GetNextUnscrapedMunicipality();
    }
}