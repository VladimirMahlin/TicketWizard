using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [Required]
    [MaxLength(255)]
    public string Username { get; set; }
    [MaxLength(255)]
    public string FirstName { get; set; }
    [MaxLength(255)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    public DateTime? LastLogin { get; set; }
    public bool IsConfirmed { get; set; } = false;
    [MaxLength(255)]
    public string RememberToken { get; set; }

    public ICollection<Order> Orders { get; set; }
}