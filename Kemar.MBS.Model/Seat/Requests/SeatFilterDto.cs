namespace Kemar.MBS.Model.Seats.Requests
{
    public class SeatFilterDto
    {
        public int? ScreenId { get; set; }
        public string? SeatCategory { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
