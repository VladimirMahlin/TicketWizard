using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public Guid? UserId { get; set; }
    public User User { get; set; }
    public Guid? EventId { get; set; }
    public Event Event { get; set; }
    public Guid? TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public string Notes { get; set; }
    public bool IsPaymentReceived { get; set; } = false;
    public bool IsCanceled { get; set; } = false;
    public bool IsRefunded { get; set; } = false;
    public decimal? Amount { get; set; }
    public decimal? AmountRefunded { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }

}