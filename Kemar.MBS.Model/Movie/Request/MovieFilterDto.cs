namespace Kemar.MBS.Model.Movie.Request
{
    public class MovieFilterDto
    {
        public string? Title { get; set; }
        public string? Category { get; set; }   
        public string? Language { get; set; }
        public string? CensorRating { get; set; } 
    }
}
