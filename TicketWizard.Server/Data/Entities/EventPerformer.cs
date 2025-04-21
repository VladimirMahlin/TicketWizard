namespace TicketWizard.Server.Data.Entities;

public class EventPerformer
{
    public Guid EventPerformerId { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    public Guid PerformerId { get; set; }
    public Performer Performer { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}