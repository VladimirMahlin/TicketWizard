using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TicketWizard.Server.Data.Entities;

public class EventOrganiser
{
    [Key]
    public Guid EventOrganiserId { get; set; }
    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    [ForeignKey("Organiser")]
    public Guid OrganiserId { get; set; }
    public Organiser Organiser { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}