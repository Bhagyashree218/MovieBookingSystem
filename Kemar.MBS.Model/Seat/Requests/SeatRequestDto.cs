namespace Kemar.MBS.Model.Seats.Requests
{
    public class SeatRequestDto
    {
        public int ScreenId { get; set; }
        public List<SeatItemDto> Seats { get; set; } = new();
    }

    public class SeatItemDto
    {
        public string SeatNumber { get; set; }
        public string Row { get; set; }
        public string SeatCategory { get; set; }
        public decimal Price { get; set; }
    }
}
