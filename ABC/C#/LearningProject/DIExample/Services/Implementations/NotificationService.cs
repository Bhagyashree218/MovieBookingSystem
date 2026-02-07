using DIExample.Models;
using DIExample.Repositories.Interfaces;
using DIExample.Services.Interfaces;

namespace DIExample.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;

        public NotificationService(INotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> SendEmail(string message)
        {
            var notification = new Notification
            {
                Type = "Email",
                Message = message,
                SentAt = DateTime.Now
            };

            await _repo.AddAsync(notification);
            return $"Email Sent: {message}";
        }

        public async Task<string> SendSms(string message)
        {
            var notification = new Notification
            {
                Type = "SMS",
                Message = message,
                SentAt = DateTime.Now
            };

            await _repo.AddAsync(notification);
            return $"SMS Sent: {message}";
        }

        public async Task<IEnumerable<Notification>> GetAll()
        {
            return await _repo.GetAllAsync();
        }



    }
}
