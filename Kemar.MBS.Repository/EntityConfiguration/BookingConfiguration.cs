using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.BookingId);

            //Properties
            builder.Property(x => x.BookingId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.BookingTime)
                   .IsRequired();

            builder.Property(x => x.TotalAmount)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            // Payment fields
            builder.Property(x => x.PaymentStatus)
                   .HasMaxLength(50);

            builder.Property(x => x.TransactionId)
                   .HasMaxLength(200);

            builder.Property(x => x.PaymentMethod)
                   .HasMaxLength(100);

            builder.Property(x => x.PaymentDate);

            builder.Property(x => x.DiscountApplied)
                   .HasColumnType("decimal(10,2)");

            //Relations
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Bookings)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Show)
                   .WithMany(x => x.Bookings)
                   .HasForeignKey(x => x.ShowId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BookingSeats)
                   .WithOne(x => x.Booking)
                   .HasForeignKey(x => x.BookingId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
