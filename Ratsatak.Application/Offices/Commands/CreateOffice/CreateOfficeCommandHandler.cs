using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Offices;

namespace Ratsatak.Application.Offices.Commands.CreateOffice;

public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, Office>
{
    private readonly IOfficeRepository _officeRepository;

    public CreateOfficeCommandHandler(IOfficeRepository officeRepository)
    {
        _officeRepository = officeRepository;
    }

    public async Task<Office> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var existingOffice = await _officeRepository.GetOfficeById(request.Id);

        if (existingOffice is not null)
            throw new RecordAlreadyExistsException($"Office with id '{request.Id}' already exists!");

        var office = Office.Create(request.Id, request.Name);

        await _officeRepository.AddOffice(office);

        return office;
    }
}