using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Common.Helpers;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Application.PossessionSheets.Commands.CreatePossessionSheet;

public class CreatePossessionSheetCommandHandler : IRequestHandler<CreatePossessionSheetCommand, PossessionSheet>
{
    private readonly IMunicipalityRepository _municipalityRepository;
    private readonly IPossessionSheetRepository _possessionSheetRepository;
    private readonly IFileHelper _fileHelper;

    public CreatePossessionSheetCommandHandler(IPossessionSheetRepository possessionSheetRepository,
        IMunicipalityRepository municipalityRepository, IFileHelper fileHelper)
    {
        _possessionSheetRepository = possessionSheetRepository;
        _municipalityRepository = municipalityRepository;
        _fileHelper = fileHelper;
    }

    public async Task<PossessionSheet> Handle(CreatePossessionSheetCommand request, CancellationToken cancellationToken)
    {
        var existingPossessionSheet =
            await _possessionSheetRepository.GetPossessionSheetById(request.Id);

        if (existingPossessionSheet is not null)
            throw new RecordAlreadyExistsException($"Possession Sheet with id '{request.Id}' already exists!");

        var possessionSheet = PossessionSheet.Create(
            request.Id,
            request.PossessionSheetNumber,
            request.TypeId,
            request.MunicipalityId,
            request.FileName,
            request.FilePath,
            request.IsHarmonized);

        if (request.IsHarmonized == false)
        {
            await _fileHelper.SaveFileToFileSystemAsync(request, cancellationToken);
        }

        request.Possessors.ForEach(possessor =>
        {
            possessionSheet.CreateAndAddPossessor(
                possessor.Name,
                possessor.Ownership,
                possessor.Address);
        });

        await _possessionSheetRepository.AddPossessionSheet(possessionSheet);
        return possessionSheet;
    }
}