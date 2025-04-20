using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Order
{
    [Key]
    public Guid OrderId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [ForeignKey("OrderStatus")]
    public Guid? OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    [ForeignKey("User")]
    public Guid? UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Event")]
    public Guid? EventId { get; set; }
    public Event Event { get; set; }
    public Guid? TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public string Notes { get; set; }
    public bool IsPaymentReceived { get; set; } = false;
    public bool IsCanceled { get; set; } = false;
    public bool IsRefunded { get; set; } = false;
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AmountRefunded { get; set; }
}