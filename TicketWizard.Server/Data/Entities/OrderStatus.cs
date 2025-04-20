using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Data.Entities;

public class OrderStatus
{
    [Key]
    public Guid OrderStatusId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
}