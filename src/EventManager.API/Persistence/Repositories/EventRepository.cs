using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EventManager.API.Domain.Models;
using EventManager.API.Persistence.Contexts;
using EventManager.API.Domain.Repositories;

namespace EventManager.API.Persistence.Repositories
{
    public class EventRepository: BaseRepository, IEventRepository
    {
        public EventRepository(AppDbContext context): base(context)
        {

        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _context.Events.Include(e => e.organizer).ToListAsync();
        }

        public async Task AddAsync(Event events)
        {
            await _context.Events.AddAsync(events);
        }

        public async Task<Event> FindByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }
        
        public void Update(Event events)
        {
           _context.Update(events);
        }

        public void Remove(Event events)
        {
            _context.Remove(events);
        }
    }
}