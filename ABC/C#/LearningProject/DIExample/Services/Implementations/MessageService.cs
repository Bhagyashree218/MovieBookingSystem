using DIExample.Services.Interfaces;

namespace DIExample.Services.Implementations
{
    public class MessageService : IMessageService
    {
        public string GetMessage() {
            return "Hello from DI";
        }
        
    }
}
