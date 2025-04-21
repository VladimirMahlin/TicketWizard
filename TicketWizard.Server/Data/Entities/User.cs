namespace TicketWizard.Server.Data.Entities;

public class User
{
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime? LastLogin { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public string RememberToken { get; set; }

    public ICollection<Order> Orders { get; set; }
}