using TicketWizard.Server.Data;
using TicketWizard.Server.Services.Interfaces;

namespace TicketWizard.Server.Services;

public class EventService(AppDbContext dbContext) : IEventService
{
}