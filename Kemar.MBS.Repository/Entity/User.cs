using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class User 
    {
        public int UserId { get; set; }     //Primary key
        public string UserName { get; set; }    
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}