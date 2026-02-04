namespace Kemar.MBS.Model.Booking.Response
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public string UserName { get; set; }
        public string TheatreName { get; set; }
        public string ScreenName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public List<string> Seats { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BookingTime { get; set; }
        public string CityName { get; set; }


    }
}
