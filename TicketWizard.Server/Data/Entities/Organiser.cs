namespace TicketWizard.Server.Data.Entities;

public class Organiser
{
    public Guid OrganiserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string OrganiserName { get; set; }
    public string About { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }

    public ICollection<EventOrganiser> EventOrganisers { get; set; }
}