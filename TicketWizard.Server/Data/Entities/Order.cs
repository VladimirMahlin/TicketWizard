using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWizard.Server.Data.Entities;

public class Order
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "OrderDate is required.")]
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Range(0, double.MaxValue, ErrorMessage = "TotalAmount must be non-negative.")]
    public decimal TotalAmount { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
}