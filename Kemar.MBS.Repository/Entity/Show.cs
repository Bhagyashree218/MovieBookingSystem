using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class Show : BaseEntity
    {
        public int ShowId { get; set; }  // Primary Key
        public int MovieId { get; set; }    // Foreign Key 
        public int ScreenId { get; set; }   // Foreign Key
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal Price { get; set; }

        public Movie Movie { get; set; }
        public Screen Screen { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
