using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.PossessionSheets.ValueObjects;

public class Possessor : ValueObject
{
    private Possessor(string? name, string? ownership, string? address)
    {
        Name = name;
        Ownership = ownership;
        Address = address;
    }

    protected Possessor()
    {
    }

    public string? Name { get; private set; }
    public string? Ownership { get; private set; }
    public string? Address { get; private set; }

    public static Possessor Create(string? name, string? ownership, string? address)
    {
        return new Possessor(name, ownership, address);
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Ownership;
        yield return Address;
    }
}