namespace TicketWizard.Server.Data.Entities;

public class Refund
{
    public Guid RefundId { get; set; }
    public Guid TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public DateTime? RefundDate { get; set; }
    public decimal? Amount { get; set; }
    public string Reason { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}