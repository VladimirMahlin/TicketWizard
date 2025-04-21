namespace TicketWizard.Server.Data.Entities;

public class Performer
{
    public Guid PerformerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string PerformerName { get; set; }

    public ICollection<EventPerformer> EventPerformers { get; set; }
}