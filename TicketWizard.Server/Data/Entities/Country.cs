using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Country
{
    [Key]
    public Guid CountryId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [Required]
    [MaxLength(255)]
    public string CountryName { get; set; }
    [Required]
    [MaxLength(3)]
    public string CountryCode { get; set; }
    [ForeignKey("Currency")]
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
    [MaxLength(5)]
    public string Iso31661 { get; set; }
    [MaxLength(10)]
    public string RegionCode { get; set; }
    [MaxLength(10)]
    public string SubRegionCode { get; set; }
    public bool IsEea { get; set; } = false;

    public ICollection<Venue> Venues { get; set; }
    public ICollection<City> Cities { get; set; }
}