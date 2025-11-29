using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class Movie : BaseEntity
    {
        public int MovieId { get; set; }  // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public int DurationInMinutes { get; set; }    
        public string PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
}
