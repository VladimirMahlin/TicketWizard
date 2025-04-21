using TicketWizard.Server.Data;
using TicketWizard.Server.Services.Interfaces;

namespace TicketWizard.Server.Services;

public class OrderService(AppDbContext dbContext) : IOrderService
{
}