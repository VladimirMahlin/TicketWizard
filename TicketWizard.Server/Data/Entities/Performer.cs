using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class Performer
{
    [Key]
    public Guid PerformerId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [MaxLength(255)]
    public string PerformerName { get; set; }

    public ICollection<EventPerformer> EventPerformers { get; set; }
}