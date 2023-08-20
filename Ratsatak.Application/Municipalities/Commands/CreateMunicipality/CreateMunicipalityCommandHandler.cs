using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Application.Municipalities.Commands.CreateMunicipality;

public class CreateMunicipalityCommandHandler : IRequestHandler<CreateMunicipalityCommand, Municipality>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMunicipalityRepository _municipalityRepository;

    public CreateMunicipalityCommandHandler(IDepartmentRepository departmentRepository,
        IMunicipalityRepository municipalityRepository)
    {
        _departmentRepository = departmentRepository;
        _municipalityRepository = municipalityRepository;
    }

    public async Task<Municipality> Handle(CreateMunicipalityCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var existingMunicipality = await _municipalityRepository.GetMunicipalityById(request.Id);

        if (existingMunicipality is not null)
            // throw new RecordAlreadyExistsException($"Municipality with id '{request.Id}' already exists!");
            return null;

        var ownerDepartment = await _departmentRepository.GetDepartmentById(request.DepartmentId);

        if (ownerDepartment is null)
            throw new OwnerRecordDoesNotExistException(
                $"Trying to create Municipality (id = {request.Id}) under Department (id = {request.DepartmentId}) that does not exits");

        var municipality = Municipality.Create(
            request.Id,
            request.Name,
            request.RegNum,
            request.DisplayName,
            request.DepartmentId);

        await _municipalityRepository.AddMunicipality(municipality);

        return municipality;
    }
}