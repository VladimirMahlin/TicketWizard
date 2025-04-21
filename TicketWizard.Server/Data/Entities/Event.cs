namespace TicketWizard.Server.Data.Entities;

public class Event
{
    public Guid EventId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<EventPerformer> EventPerformers { get; set; }
    public ICollection<EventOrganiser> EventOrganisers { get; set; }
    public ICollection<Order> Orders { get; init; }
    
    public ICollection<Ticket> Tickets { get; set; }
}