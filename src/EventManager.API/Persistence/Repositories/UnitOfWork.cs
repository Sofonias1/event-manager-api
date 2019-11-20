using System.Threading.Tasks;
using EventManager.API.Domain.Repositories;
using EventManager.API.Persistence.Contexts;

namespace EventManager.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly AppDbContext _context;

       public UnitOfWork(AppDbContext context)
       {
           _context = context;
       }

       public async Task CompleteAsync()
       {
           await _context.SaveChangesAsync();
       }
    }
}