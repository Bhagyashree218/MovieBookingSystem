using DIExample.Data;
using DIExample.Models;
using DIExample.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIExample.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }
    }
}
