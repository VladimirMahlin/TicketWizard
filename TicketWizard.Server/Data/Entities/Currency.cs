using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class Currency
{
    [Key]
    public Guid CurrencyId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(3)]
    public string Code { get; set; }
    [MaxLength(5)]
    public string Symbol { get; set; }
    [MaxLength(50)]
    public string SubCurrency { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Country> Countries { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}