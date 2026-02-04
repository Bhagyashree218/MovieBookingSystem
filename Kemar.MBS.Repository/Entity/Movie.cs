using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class Movie : BaseEntity
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Media- local file paths only
        public string? PosterUrl { get; set; }
        public string? BannerUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? TrailerUrl { get; set; }
        // Multiple images :comma-separated local file paths
        public string? GalleryImages { get; set; }
        public string? CastImages { get; set; }
        // Movie Metadata
        public string? Director { get; set; }
        public string? Cast { get; set; }
        public string? CensorRating { get; set; }
        public double? ImdbRating { get; set; }
        public int? LikesPercentage { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
}
