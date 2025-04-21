using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Refund
{
    [Key] public Guid RefundId { get; set; }
    [ForeignKey("Transaction")] public Guid TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public DateTime? RefundDate { get; set; }
    [Column(TypeName = "decimal(10, 2)")] public decimal? Amount { get; set; }
    [MaxLength(1000)] public string Reason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}