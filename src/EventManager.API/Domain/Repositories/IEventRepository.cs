using System.Threading.Tasks;
using System.Collections.Generic;

using EventManager.API.Domain.Models;

namespace EventManager.API.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> ListAsync();
        Task AddAsync(Event events);
        
	    Task<Event> FindByIdAsync(int id);
	    void Update(Event events);

        void Remove(Event events);
    }
}