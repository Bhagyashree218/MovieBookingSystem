using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class BookingSeatConfiguration : IEntityTypeConfiguration<BookingSeat>
    {
        public void Configure(EntityTypeBuilder<BookingSeat> builder)
        {
            builder.HasKey(x => x.BookingSeatId);

            //Properties
            builder.Property(x => x.BookingSeatId)
                    .ValueGeneratedOnAdd();

            //Relations
            builder.HasOne(x => x.Booking)
                   .WithMany(x => x.BookingSeats)
                   .HasForeignKey(x => x.BookingId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Seat)
                   .WithMany(x => x.BookingSeats)
                   .HasForeignKey(x => x.SeatId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
