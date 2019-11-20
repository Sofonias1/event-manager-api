using System.Threading.Tasks;
using System.Collections.Generic;
using EventManager.API.Domain.Models;
using EventManager.API.Domain.Services.Communication;

namespace EventManager.API.Domain.Services 
{
    public interface IOrganizerService
    {
        Task<IEnumerable<Organizer>> ListAsync();
        Task<OrganizerResponse> SaveAsync(Organizer organizer);
        Task<OrganizerResponse> UpdateAsync(int id, Organizer organizer);
        Task<OrganizerResponse> DeleteAsync(int id);
    }
}