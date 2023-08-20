namespace Ratsatak.Contracts.Municipalities;

public record SetMunicipalityScrapedStatusRequest(
    int Id,
    bool Scraped
);