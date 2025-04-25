using Microsoft.EntityFrameworkCore;
using TicketWizard.Server.Data;
using TicketWizard.Server.Data.Entities;
using TicketWizard.Server.DTOs;
using TicketWizard.Server.Services.Interfaces;

namespace TicketWizard.Server.Services;

public class EventService(AppDbContext dbContext) : IEventService
{
    public async Task<EventDto> GetEventById(Guid id)
    {
        var @event = await dbContext.Events.FindAsync(id);

        if (@event == null)
        {
            throw new KeyNotFoundException("Event not found");
        }
        
        return MapToEventDto(@event);
    }

    public async Task<IEnumerable<EventDto>> GetAllEvents()
    {
        var events = await dbContext.Events
            .Where(e => e.DeletedAt == null)
            .ToListAsync();
        
        return events.Select(MapToEventDto);
    }

    public async Task<EventDto> CreateEvent(EventCreateDto eventCreateDto)
    {
        var newEvent = new Event
        {
            EventId = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            EventName = eventCreateDto.EventName,
            Description = eventCreateDto.Description,
            StartDate = eventCreateDto.StartDate,
            EndDate = eventCreateDto.EndDate
        };

        await dbContext.Events.AddAsync(newEvent);
        await dbContext.SaveChangesAsync();
        
        return MapToEventDto(newEvent);
    }

    public async Task<bool> UpdateEvent(EventUpdateDto eventUpdateDto)
    {
        var existingEvent = await dbContext.Events.FindAsync(eventUpdateDto.EventId);

        if (existingEvent is not { DeletedAt: null })
        {
            throw new KeyNotFoundException("Event not found");
        }

        existingEvent.EventName = eventUpdateDto.EventName;
        existingEvent.Description = eventUpdateDto.Description;
        existingEvent.StartDate = eventUpdateDto.StartDate;
        existingEvent.EndDate = eventUpdateDto.EndDate;
        existingEvent.UpdatedAt = DateTime.UtcNow;

        dbContext.Events.Update(existingEvent);
        await dbContext.SaveChangesAsync();
        
        return true;;
    }

    public async Task<bool> DeleteEvent(Guid id)
    {
        var existingEvent = await dbContext.Events.FindAsync(id);

        if (existingEvent is not { DeletedAt: null })
        {
            throw new KeyNotFoundException("Event not found");
        }

        existingEvent.DeletedAt = DateTime.UtcNow;

        dbContext.Events.Update(existingEvent);
        await dbContext.SaveChangesAsync();

        return true;
    }
    
    private static EventDto MapToEventDto(Event @event)
    {
        return new EventDto
        {
            EventId = @event.EventId,
            CreatedAt = @event.CreatedAt,
            UpdatedAt = @event.UpdatedAt,
            EventName = @event.EventName,
            Description = @event.Description,
            StartDate = @event.StartDate,
            EndDate = @event.EndDate
        };
    }

}