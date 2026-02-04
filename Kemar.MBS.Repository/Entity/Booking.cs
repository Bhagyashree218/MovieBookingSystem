using Kemar.MBS.Repository.Entity.BaseEntities;

namespace Kemar.MBS.Repository.Entity
{
    public class Booking : BaseEntity
    {
        public int BookingId { get; set; }  // Primary Key
        public int UserId { get; set; }     // Foreign Key
        public int ShowId { get; set; }     // Foreign Key

        public DateTime BookingTime { get; set; }
        public decimal TotalAmount { get; set; }

        public string? PaymentStatus { get; set; }         // Pending, Success, Failed
        public string? TransactionId { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }

       
        public decimal? DiscountApplied { get; set; }    // analytics for Admin
        public string? Source { get; set; } 

        public User User { get; set; }
        public Show Show { get; set; }
        public ICollection<BookingSeat> BookingSeats { get; set; }
    }
}
