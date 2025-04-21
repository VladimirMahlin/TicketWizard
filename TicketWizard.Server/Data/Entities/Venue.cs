using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Venue
{
    [Key] public Guid VenueId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [MaxLength(255)] public string VenueName { get; set; }
    [MaxLength(1000)] public string Description { get; set; }
    [ForeignKey("Country")] public Guid? CountryId { get; set; }
    public Country Country { get; set; }
    [ForeignKey("City")] public Guid? CityId { get; set; }
    public City City { get; set; }
    [MaxLength(255)] public string Address1 { get; set; }
    [MaxLength(255)] public string Address2 { get; set; }
    [MaxLength(20)] public string PostalCode { get; set; }
    public int? MaxCapacity { get; set; }
    public bool IsActive { get; set; } = true;
}