using MediatR;
using Ratsatak.Application.Common.Errors;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Departments;

namespace Ratsatak.Application.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IOfficeRepository _officeRepository;

    public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository,
        IOfficeRepository officeRepository)
    {
        _departmentRepository = departmentRepository;
        _officeRepository = officeRepository;
    }

    public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var existingDepartment = await _departmentRepository.GetDepartmentById(request.Id);

        if (existingDepartment is not null)
            throw new RecordAlreadyExistsException($"Department with id '{request.Id}' already exists!");

        var ownerOffice = await _officeRepository.GetOfficeById(request.OfficeId);

        if (ownerOffice is null)
            throw new OwnerRecordDoesNotExistException(
                $"Trying to create Department (id = {request.Id}) under Office (id = {request.OfficeId}) that does not exits");

        var department = Department.Create(
            request.Id,
            request.Name,
            request.OfficeId);

        await _departmentRepository.AddDepartment(department);

        return department;
    }
}