using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.Offices;

public class Office : AggregateRoot<int>
{
    private Office(int officeId, string name, DateTime createdDateTime, DateTime updatedDateTime) :
        base(officeId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private Office()
    {
    }

    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static Office Create(int officeId, string name)
    {
        return new Office(officeId, name, DateTime.UtcNow, DateTime.UtcNow);
    }
}