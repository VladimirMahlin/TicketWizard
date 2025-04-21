namespace TicketWizard.Server.Data.Entities;

public class EventOrganiser
{
    public Guid EventOrganiserId { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    public Guid OrganiserId { get; set; }
    public Organiser Organiser { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}