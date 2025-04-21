using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class Gateway
{
    [Key]
    public Guid GatewayId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}