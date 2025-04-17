using TicketWizard.Server.Data.Entities;

namespace TicketWizard.Server.Data.Repositories.Interfaces;

public interface ITicketRepository
{
    Task<Ticket> GetByIdAsync(int id);
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task<IEnumerable<Ticket>> GetByEventIdAsync(int eventId);
    Task AddAsync(Ticket entity);
    Task UpdateAsync(Ticket entity);
    Task DeleteAsync(int id);
}