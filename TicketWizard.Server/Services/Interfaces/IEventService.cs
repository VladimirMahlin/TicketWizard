using TicketWizard.Server.DTOs;

namespace TicketWizard.Server.Services.Interfaces;

public interface IEventService
{
    Task<EventDto> GetEventById(Guid id);
    Task<IEnumerable<EventDto>> GetAllEvents();
    Task<EventDto> CreateEvent(EventCreateDto eventCreateDto);
    Task<bool> UpdateEvent(EventUpdateDto eventUpdateDto);
    Task<bool> DeleteEvent(Guid id);
}