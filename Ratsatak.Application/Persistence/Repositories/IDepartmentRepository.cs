using Ratsatak.Domain.Departments;

namespace Ratsatak.Application.Persistence.Repositories;

public interface IDepartmentRepository
{
    Task AddDepartment(Department department);
    Task<Department?> GetDepartmentById(int id);
}