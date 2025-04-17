using TicketWizard.Server.Data.Entities;

namespace TicketWizard.Server.Data.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task AddAsync(Order entity);
    Task UpdateAsync(Order entity);
    Task DeleteAsync(int id);
    Task<Order> GetOrderWithTicketsAsync(int orderId);
}