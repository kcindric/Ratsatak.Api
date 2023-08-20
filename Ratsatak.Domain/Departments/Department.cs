using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.Departments;

public class Department : AggregateRoot<int>
{
    private Department(int departmentId, string name, int officeId, DateTime createdDateTime,
        DateTime updatedDateTime) :
        base(departmentId)
    {
        Id = departmentId;
        Name = name;
        OfficeId = officeId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private Department()
    {
    }

    public string Name { get; private set; }
    public int OfficeId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static Department Create(int departmentId, string name, int officeId)
    {
        return new Department(departmentId, name, officeId, DateTime.UtcNow, DateTime.UtcNow);
    }
}