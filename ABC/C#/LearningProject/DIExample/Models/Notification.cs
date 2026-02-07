namespace DIExample.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Type { get; set; } // Email / SMS
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }

}
