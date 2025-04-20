using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Event
{
    [Key]
    public Guid EventId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [MaxLength(255)]
    public string EventName { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<EventPerformer> EventPerformers { get; set; }
    public ICollection<EventOrganiser> EventOrganisers { get; set; }
    public ICollection<Order> Orders { get; set; }
}