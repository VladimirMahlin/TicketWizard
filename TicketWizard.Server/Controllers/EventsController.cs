using Microsoft.AspNetCore.Mvc;
using TicketWizard.Server.Services.Interfaces;

namespace TicketWizard.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(IEventService eventService) : ControllerBase
{
}