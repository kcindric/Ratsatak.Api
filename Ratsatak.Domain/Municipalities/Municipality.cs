using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.Municipalities;

public class Municipality : AggregateRoot<int>
{
    private Municipality(int municipalityId, string name, int regNum, string displayName,
        int departmentId, DateTime createdDateTime, DateTime updatedDateTime) : base(municipalityId)
    {
        Name = name;
        RegNum = regNum;
        DisplayName = displayName;
        DepartmentId = departmentId;
        Scraped = false;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private Municipality()
    {
    }

    public string Name { get; private set; }
    public int RegNum { get; private set; }
    public string DisplayName { get; private set; }
    public int DepartmentId { get; private set; }
    public bool Scraped { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static Municipality Create(int municipalityId, string name, int regNum, string displayName,
        int departmentId)
    {
        return new Municipality(
            municipalityId,
            name,
            regNum,
            displayName,
            departmentId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void UpdateMunicipalityScrapedStatus(bool newScrapedStatus)
    {
        Scraped = newScrapedStatus;
    }
}