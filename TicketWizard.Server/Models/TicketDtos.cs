using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Models
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required] public int EventId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public bool IsReserved { get; set; }
    }

    public class TicketCreateDto
    {
        [Required(ErrorMessage = "EventId is required.")]
        public int EventId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
    }

    public class TicketUpdateDto
    {
        [Required] public int Id { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal? Price { get; set; }

        public bool? IsReserved { get; set; }
    }
}