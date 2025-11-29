namespace Kemar.MBS.Model.Booking.Request
{
    public class BookingRequestDto
    {
        public int UserId { get; set; }
        public int ShowId { get; set; }
        public List<int> SeatIds { get; set; }
    }
}
