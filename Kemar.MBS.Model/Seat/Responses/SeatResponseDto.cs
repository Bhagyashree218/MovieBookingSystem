namespace Kemar.MBS.Model.Seat.Response
{
    public class SeatResponseDto
    {
        public int SeatId { get; set; }
        public string SeatType { get; set; }
        public string SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
