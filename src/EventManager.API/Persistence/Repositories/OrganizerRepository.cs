using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EventManager.API.Domain.Models;
using EventManager.API.Persistence.Contexts;
using EventManager.API.Domain.Repositories;

namespace EventManager.API.Persistence.Repositories
{
    public class OrganizerRepository: BaseRepository, IOrganizerRepository
    {
        public OrganizerRepository(AppDbContext context): base(context)
        {

        }

        public async Task<IEnumerable<Organizer>> ListAsync()
        {
            return await _context.Organizers.ToListAsync();
        }

        public async Task AddAsync(Organizer organizer)
        {
            await _context.Organizers.AddAsync(organizer);
        }
        public async Task<Organizer> FindByIdAsync(int id)
        {
            return await _context.Organizers.FindAsync(id);
        }

        public void Update(Organizer organizer)
        {
           _context.Update(organizer);
        }

        public void Remove(Organizer organizer)
        {
            _context.Remove(organizer);
        }
    }
}