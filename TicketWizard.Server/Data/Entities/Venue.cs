namespace TicketWizard.Server.Data.Entities;

public class Venue
{
    public Guid VenueId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string VenueName { get; set; }
    public string Description { get; set; }
    public Guid? CountryId { get; set; }
    public Country Country { get; set; }
    public Guid? CityId { get; set; }
    public City City { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string PostalCode { get; set; }
    public int MaxCapacity { get; set; }
    public bool IsActive { get; set; } = true;
}