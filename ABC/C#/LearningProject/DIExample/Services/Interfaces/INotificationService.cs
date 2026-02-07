using DIExample.Models;

namespace DIExample.Services.Interfaces
{
    public interface INotificationService
    {
        Task<string> SendEmail(string message);
        Task<string> SendSms(string message);
        Task<IEnumerable<Notification>> GetAll();
    }

}
