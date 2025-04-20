using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TicketWizard.Server.Data.Entities;

public class EventPerformer
{
    [Key]
    public Guid EventPerformerId { get; set; }
    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    [ForeignKey("Performer")]
    public Guid PerformerId { get; set; }
    public Performer Performer { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}