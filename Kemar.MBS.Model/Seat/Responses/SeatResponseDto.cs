namespace Kemar.MBS.Model.Seat.Response
{
    public class SeatResponseDto
    {
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public string RowNumber { get; set; }
        public bool IsAvailable { get; set; }
        public string SeatCategory { get; set; }
        //public decimal Price { get; set; }
    }
}
