namespace Kemar.MBS.Model.Movie.Response
{
    public class MovieResponseDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public string? BannerUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public string? GalleryImages { get; set; }
        public string? CastImages { get; set; }
        public string? Director { get; set; }
        public string? Cast { get; set; }
        public string? CensorRating { get; set; }
        public double? ImdbRating { get; set; }
        public int? LikesPercentage { get; set; }
    }
}
