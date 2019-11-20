using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;

using EventManager.API.Domain.Services;
using EventManager.API.Resources;
using EventManager.API.Domain.Models;
using EventManager.API.Extensions;
using EventManager.API.Domain.Services.Communication;

namespace EventManager.API.Controllers
{
    [Route("/api/[controller]")]
    public class EventsController: Controller 
    {
      private readonly IEventService _eventService;
      private readonly IMapper _mapper;
      private readonly ILogger<EventsController> _logger;

      public EventsController(IEventService eventService, IMapper mapper, ILogger<EventsController> logger)
      {
          this._eventService = eventService;
          this._mapper = mapper;
          this._logger = logger;
      }

       [HttpGet]
        public async Task<IEnumerable> GetAllAsync()
        {
            var events = await _eventService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EventResource resource)
        {
             if(!ModelState.IsValid)
                 return BadRequest(ModelState.GetErrorMessages());

	        var events = _mapper.Map<EventResource, Event>(resource);
            var result =  await this._eventService.SaveAsync(events);

            if(!result.Success) 
                return BadRequest(result.Message);
            
            var eventResource = _mapper.Map<Event, EventResource>(result.Event);

            return Ok(eventResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] EventResource resource)
        {
            if(!ModelState.IsValid)
               return BadRequest(ModelState.GetErrorMessages());

            var events = _mapper.Map<EventResource, Event>(resource);
            var results = await _eventService.UpdateAsync(id, events);

            if(!results.Success)
                return BadRequest(results.Message);
            
            var eventResource = _mapper.Map<Event, EventResource>(results.Event);

            return Ok(eventResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _eventService.DeleteAsync(id);

            if(!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Event, EventResource>(result.Event);
            return Ok(eventResource);
        }
    }
}