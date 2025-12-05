namespace Kemar.MBS.Model.Show.Response
{
    public class ShowResponseDto
    {
        public int ShowId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal Price { get; set; }
    }
}
