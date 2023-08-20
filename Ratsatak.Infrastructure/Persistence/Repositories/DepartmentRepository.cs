using Microsoft.EntityFrameworkCore;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Domain.Departments;
using Ratsatak.Infrastructure.Persistence.DbContexts;

namespace Ratsatak.Infrastructure.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly RatsatakDbContext _dbContext;


    public DepartmentRepository(RatsatakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddDepartment(Department department)
    {
        await _dbContext.AddAsync(department);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Department?> GetDepartmentById(int id)
    {
        return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
    }
}