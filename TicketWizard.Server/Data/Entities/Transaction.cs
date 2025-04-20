using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace TicketWizard.Server.Data.Entities;

public class Transaction
{
    [Key]
    public Guid TransactionId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    [ForeignKey("TransactionType")]
    public Guid? TransactionTypeId { get; set; }
    public TransactionType TransactionType { get; set; }
    [ForeignKey("TransactionStatus")]
    public Guid? TransactionStatusId { get; set; }
    public TransactionStatus TransactionStatus { get; set; }
    public DateTime? TransactionDate { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }
    [ForeignKey("Currency")]
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
    [ForeignKey("PaymentMethod")]
    public Guid? PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    [MaxLength(255)]
    public string TransactionReference { get; set; }
    [ForeignKey("Order")]
    public Guid? OrderId { get; set; }
    public Order Order { get; set; }
    [ForeignKey("Refund")]
    public Guid? RefundId { get; set; }
    public Transaction Refund { get; set; }
    public string Description { get; set; }
    [ForeignKey("Gateway")]
    public Guid? GatewayId { get; set; }
    public Gateway Gateway { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Fees { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Refund> Refunds { get; set; }
    public ICollection<Transaction> InverseRefund { get; set; }
}