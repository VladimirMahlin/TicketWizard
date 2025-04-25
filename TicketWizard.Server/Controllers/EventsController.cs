using Microsoft.AspNetCore.Mvc;
using TicketWizard.Server.DTOs;
using TicketWizard.Server.Services.Interfaces;

namespace TicketWizard.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(IEventService eventService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<EventDto>> GetAllEvents()
    {
        return await eventService.GetAllEvents();
    }
    
    [HttpGet("{id}")]
    public async Task<EventDto> GetEventById(Guid id)
    {
        return await eventService.GetEventById(id);
    }
    
    [HttpPost]
    public async Task<EventDto> CreateEvent(EventCreateDto eventCreateDto)
    {
        return await eventService.CreateEvent(eventCreateDto);
    }
    
    [HttpPut]
    public async Task<bool> UpdateEvent(EventUpdateDto eventUpdateDto)
    {
        return await eventService.UpdateEvent(eventUpdateDto);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteEvent(Guid id)
    {
        return await eventService.DeleteEvent(id);   
    }
}