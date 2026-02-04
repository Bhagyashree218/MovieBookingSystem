using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class Screen : BaseEntity
    {
        public int ScreenId { get; set; }   // Primary Key
        public int TheatreId { get; set; }  //Foreign Key
        public string ScreenName { get; set; }

        public Theatre Theatre { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
