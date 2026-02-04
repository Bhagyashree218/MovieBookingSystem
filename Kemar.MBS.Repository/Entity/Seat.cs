namespace Kemar.MBS.Repository.Entity
{
    public class Seat
    {
        public int SeatId { get; set; } // Primary Key
        public int ScreenId { get; set; }   // Foreign Key 
        public string SeatNumber { get; set; }
        public string RowNumber { get; set; }
        public bool IsAvailable { get; set; } = true;

        public string SeatCategory { get; set; }   
        public decimal Price { get; set; }        
        public Screen Screen { get; set; }
        public ICollection<BookingSeat> BookingSeats { get; set; }
    }
}
