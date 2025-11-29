namespace Kemar.MBS.Model.Booking.Response
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<string> Seats { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
