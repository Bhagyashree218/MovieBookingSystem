using DIExample.Models;

namespace DIExample.Repositories.Interfaces
{
   
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<IEnumerable<Notification>> GetAllAsync();
    }
}
