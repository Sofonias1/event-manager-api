using System.Threading.Tasks;

namespace EventManager.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
       Task CompleteAsync();
    }
}