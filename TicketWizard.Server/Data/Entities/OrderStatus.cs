namespace TicketWizard.Server.Data.Entities;

public class OrderStatus
{
    public Guid OrderStatusId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
}