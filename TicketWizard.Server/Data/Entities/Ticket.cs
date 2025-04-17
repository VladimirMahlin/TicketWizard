using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Ticket
{
    [Key] public int Id { get; set; }

    [ForeignKey("Event")]
    [Required(ErrorMessage = "EventId is required.")]
    public int EventId { get; set; }

    public Event Event { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    public bool IsReserved { get; set; }

    [ForeignKey("Order")] public int? OrderId { get; set; }
    public Order Order { get; set; }
}