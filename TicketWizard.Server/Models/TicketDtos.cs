using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }
    }

    public class TicketCreateDto
    {
        [Required] public int EventId { get; set; }

        [Range(0.01, double.MaxValue)] public decimal Price { get; set; }
    }

    public class TicketUpdateDto
    {
        [Required] public int Id { get; set; }

        [Range(0.01, double.MaxValue)] public decimal? Price { get; set; }

        public bool? IsReserved { get; set; }
    }
}