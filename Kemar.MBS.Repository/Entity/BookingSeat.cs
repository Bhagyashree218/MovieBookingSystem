namespace Kemar.MBS.Repository.Entity
{
    public class BookingSeat 
    {
        public int BookingSeatId { get; set; }   // Primary Key
        public int BookingId { get; set; }      //Foreign Key
        public int SeatId { get; set; }     //Foreign Key

        public Booking Booking { get; set; }
        public Seat Seat { get; set; }
    }
}
