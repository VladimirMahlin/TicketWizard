using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class Event
{
    [Key]
    public Guid EventId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; init; }
    public DateTime? DeletedAt { get; init; }
    [MaxLength(255)]
    public string EventName { get; init; }
    [MaxLength(1000)]
    public string Description { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }

    public ICollection<EventPerformer> EventPerformers { get; init; }
    public ICollection<EventOrganiser> EventOrganisers { get; init; }
    public ICollection<Order> Orders { get; init; }
}