using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Common.Helpers;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.LandRegistryUnits;

namespace Ratsatak.Application.LandRegistryUnits.Commands.CreateLandRegistryUnit;

public class CreateLandRegistryUnitCommandHandler : IRequestHandler<CreateLandRegistryUnitCommand, LandRegistryUnit>
{
    private readonly ILandRegistryUnitRepository _landRegistryUnitRepository;
    private readonly IFileHelper _fileHelper;

    public CreateLandRegistryUnitCommandHandler(ILandRegistryUnitRepository landRegistryUnitRepository, IFileHelper fileHelper)
    {
        _landRegistryUnitRepository = landRegistryUnitRepository;
        _fileHelper = fileHelper;
    }

    public async Task<LandRegistryUnit> Handle(CreateLandRegistryUnitCommand request, CancellationToken cancellationToken)
    {
        // ID is mapped as 0, need to fix that
        var existingLandRegistryUnit =
            await _landRegistryUnitRepository
                .GetLandRegistryUnitById(request.Id);
        
        if(existingLandRegistryUnit is not null)
            throw new RecordAlreadyExistsException($"Land Registry Unit with id '{request.Id}' already exists!");

        var landRegistryUnit = LandRegistryUnit.Create(
            request.Id,
            request.LandRegistryUnitNumber,
            request.MunicipalityId,
            request.Status,
            request.Verificated,
            request.Condominiums,
            request.MainBookId,
            request.FileName,
            request.FilePath);
        
        await _fileHelper.SaveFileToFileSystemAsync(request, cancellationToken);

        await _landRegistryUnitRepository.AddLandRegistryUnit(landRegistryUnit);
        return landRegistryUnit;
    }
}