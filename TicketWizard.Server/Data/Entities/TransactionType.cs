namespace TicketWizard.Server.Data.Entities;

public class TransactionType
{
    public Guid TransactionTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Transaction> Transactions { get; set; }
}