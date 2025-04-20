using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class City
{
    [Key]
    public Guid CityId { get; set; }
    [MaxLength(255)]
    public string CityName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [ForeignKey("Country")]
    public Guid CountryId { get; set; }
    public Country Country { get; set; }

    public ICollection<Venue> Venues { get; set; }
}