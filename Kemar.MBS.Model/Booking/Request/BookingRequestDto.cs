namespace Kemar.MBS.Model.Booking.Request
{
    public class BookingRequestDto
    {
        public int ShowId { get; set; }
        public List<int> SeatIds { get; set; }
    }
}
