namespace TicketWizard.Server.Data.Entities;

public class City
{
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<Venue> Venues { get; set; }
}