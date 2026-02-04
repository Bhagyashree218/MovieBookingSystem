namespace Kemar.MBS.Model.Show.Response
{
    public class ShowResponseDto
    {
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int CityId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal Price { get; set; }
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
    
        public string CityName { get; set; }
    }
}
