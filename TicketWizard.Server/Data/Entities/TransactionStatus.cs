using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class TransactionStatus
{
    [Key]
    public Guid TransactionStatusId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}