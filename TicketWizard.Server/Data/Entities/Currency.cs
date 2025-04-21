namespace TicketWizard.Server.Data.Entities;

public class Currency
{
    public Guid CurrencyId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Symbol { get; set; }
    public string SubCurrency { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Country> Countries { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}