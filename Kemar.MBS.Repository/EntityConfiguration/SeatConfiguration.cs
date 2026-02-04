using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(x => x.SeatId);

            //Properties
            builder.Property(x => x.SeatId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.SeatNumber)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(x => x.RowNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.IsAvailable)
                   .IsRequired();

            builder.Property(x => x.SeatCategory)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.Price)
                    .IsRequired()
                    .HasPrecision(10, 2);


            //Relations
            builder.HasOne(x => x.Screen)
                   .WithMany(x => x.Seats)
                   .HasForeignKey(x => x.ScreenId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BookingSeats)
                   .WithOne(x => x.Seat)
                   .HasForeignKey(x => x.SeatId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
