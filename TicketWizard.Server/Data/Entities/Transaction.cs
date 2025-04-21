namespace TicketWizard.Server.Data.Entities;

public class Transaction
{
    public Guid TransactionId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? TransactionTypeId { get; set; }
    public TransactionType TransactionType { get; set; }
    public Guid? TransactionStatusId { get; set; }
    public TransactionStatus TransactionStatus { get; set; }
    public DateTime? TransactionDate { get; set; }
    public decimal? Amount { get; set; }
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public Guid? PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string TransactionReference { get; set; }
    public Guid? OrderId { get; set; }
    public Order Order { get; set; }
    public Guid? RefundId { get; set; }
    public Transaction Refund { get; set; }
    public string Description { get; set; }
    public Guid? GatewayId { get; set; }
    public Gateway Gateway { get; set; }
    public decimal? Fees { get; set; }
    
    public ICollection<Refund> Refunds { get; set; }
}