using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.LandRegistryUnits;

public class LandRegistryUnit : AggregateRoot<int>
{
    public LandRegistryUnit(
        int landRegistryUnitId,
        string? landRegistryUnitNumber,
        int municipalityId,
        string? status,
        bool? verificated,
        bool? condominiums,
        int? mainBookId,
        string? fileName, 
        string? filePath,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(landRegistryUnitId)
    {
        LandRegistryUnitNumber = landRegistryUnitNumber;
        MunicipalityId = municipalityId;
        Status = status;
        Verificated = verificated;
        Condominiums = condominiums;
        MainBookId = mainBookId;
        FileName = fileName;
        FilePath = filePath;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    private LandRegistryUnit(){}

    public string? LandRegistryUnitNumber { get; private set; }
    public int MunicipalityId { get; private set; }
    public string? Status { get; private set; }
    public bool? Verificated { get; private set; }
    public bool? Condominiums { get; private set; }
    public int? MainBookId { get; private set; }
    public string? FileName { get; private set; }
    public string? FilePath { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static LandRegistryUnit Create(
        int landRegistryUnitId,
        string? landRegistryUnitNumber,
        int municipalityId,
        string? status,
        bool? verificated,
        bool? condominiums,
        int? mainBookId,
        string? fileName,
        string? filePath)
    {
        return new LandRegistryUnit(
            landRegistryUnitId,
            landRegistryUnitNumber,
            municipalityId,
            status,
            verificated,
            condominiums,
            mainBookId,
            fileName,
            filePath,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}