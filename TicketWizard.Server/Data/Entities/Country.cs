namespace TicketWizard.Server.Data.Entities;

public class Country
{
    public Guid CountryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string CountryName { get; set; }
    public string CountryCode { get; set; }
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public string Iso31661 { get; set; }
    public string RegionCode { get; set; }
    public string SubRegionCode { get; set; }
    public bool IsEea { get; set; } = false;

    public ICollection<Venue> Venues { get; set; }
    public ICollection<City> Cities { get; set; }
}