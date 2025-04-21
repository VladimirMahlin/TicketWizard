using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class Organiser
{
    [Key]
    public Guid OrganiserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [MaxLength(255)]
    public string OrganiserName { get; set; }
    [MaxLength(1000)]
    public string About { get; set; }
    [MaxLength(255)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [MaxLength(255)]
    public string Facebook { get; set; }
    [MaxLength(255)]
    public string Twitter { get; set; }

    public ICollection<EventOrganiser> EventOrganisers { get; set; }
}