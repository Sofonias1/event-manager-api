using System.Threading.Tasks;
using System.Collections.Generic;

using EventManager.API.Domain.Models;

namespace EventManager.API.Domain.Repositories
{
    public interface IOrganizerRepository
    {
        Task<IEnumerable<Organizer>> ListAsync();

        Task AddAsync(Organizer organizer);
        
	    Task<Organizer> FindByIdAsync(int id);
	    void Update(Organizer organizer);

        void Remove(Organizer organizer);
    }
}