namespace TicketWizard.Server.Data.Entities;

public class Ticket
{
    public Guid TicketId { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    public decimal Price { get; set; }
    public bool IsReserved { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}