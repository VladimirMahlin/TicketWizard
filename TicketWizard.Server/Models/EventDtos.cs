using System.ComponentModel.DataAnnotations;

namespace TicketWizard.Server.Models
{
    public class EventDto
    {
        public int Id { get; set; }

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

        [Range(0.01, double.MaxValue, ErrorMessage = "BasePrice must be greater than 0.")]
        public decimal BasePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AvailableTickets must be non-negative.")]
        public int AvailableTickets { get; set; }
    }

    public class EventCreateDto
    {
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

        [Range(0.01, double.MaxValue, ErrorMessage = "BasePrice must be greater than 0.")]
        public decimal BasePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AvailableTickets must be non-negative.")]
        public int AvailableTickets { get; set; }
    }

    public class EventUpdateDto
    {
        [Required] public int Id { get; set; }

        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        public DateTime? Date { get; set; }

        [MaxLength(255, ErrorMessage = "Location cannot exceed 255 characters.")]
        public string Location { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "BasePrice must be greater than 0.")]
        public decimal? BasePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AvailableTickets must be non-negative.")]
        public int? AvailableTickets { get; set; }
    }
}