using System.Threading.Tasks;
using System.Collections.Generic;
using EventManager.API.Domain.Models;
using EventManager.API.Domain.Services.Communication;

namespace EventManager.API.Domain.Services 
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> ListAsync();
        Task<EventResponse> SaveAsync(Event Event);
        Task<EventResponse> UpdateAsync(int id, Event Event);
        Task<EventResponse> DeleteAsync(int id);
    }
}