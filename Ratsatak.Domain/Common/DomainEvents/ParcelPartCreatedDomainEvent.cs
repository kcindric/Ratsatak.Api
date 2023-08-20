using Ratsatak.Domain.Common.Models;

namespace Ratsatak.Domain.Common.DomainEvents;

public record ParcelPartCreatedDomainEvent(int ParcelPartId,
    int PossessionSheetId) : IDomainEvent;