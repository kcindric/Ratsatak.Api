using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.PossessionSheets;
using Ratsatak.Domain.PossessionSheets.ValueObjects;

namespace Ratsatak.Application.PossessionSheets.Commands.AddPossessorsToParcelSheet;

public class AddPossessorsToPossessionSheetCommandHandler :
    IRequestHandler<AddPossessorsToPossessionSheetCommand, PossessionSheet?>
{
    private readonly IPossessionSheetRepository _possessionSheetRepository;

    public AddPossessorsToPossessionSheetCommandHandler(IPossessionSheetRepository possessionSheetRepository)
    {
        _possessionSheetRepository = possessionSheetRepository;
    }

    public async Task<PossessionSheet?> Handle(AddPossessorsToPossessionSheetCommand request,
        CancellationToken cancellationToken)
    {
        var possessionSheet =
            await _possessionSheetRepository.GetPossessionSheetById(
                request.Id);
        if (possessionSheet is null)
            throw new RecordDoesNotExistException($"Can't find possession sheet with id = {request.Id}");

        var newPossessors = ExtractNewPossessors(request, possessionSheet);

        if (newPossessors.Count > 0)
        {
            newPossessors.ForEach(newPossessor => { possessionSheet.AddPossessor(newPossessor); });

            await _possessionSheetRepository.UpdatePossessionSheet(possessionSheet);
        }

        return possessionSheet;
    }

    private static List<Possessor> ExtractNewPossessors(
        AddPossessorsToPossessionSheetCommand request, 
        PossessionSheet possessionSheet)
    {
        var currentPossessors = possessionSheet.Possessors.ToList();
        var possibleNewPossessors = request.Possessors
            .Select(possessor =>
                Possessor.Create(possessor.Name,
                    possessor.Ownership,
                    possessor.Address))
            .ToList();

        var newPossessors = possibleNewPossessors
            .Except(currentPossessors)
            .ToList();
        return newPossessors;
    }
}