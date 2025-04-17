using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Event
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
    public string Name { get; set; }

    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [MaxLength(255, ErrorMessage = "Location cannot exceed 255 characters.")]
    public string Location { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "BasePrice must be greater than 0.")]
    public decimal BasePrice { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "AvailableTickets must be non-negative.")]
    public int AvailableTickets { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}