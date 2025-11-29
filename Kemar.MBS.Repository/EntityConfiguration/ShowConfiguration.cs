using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.HasKey(x => x.ShowId);

            //Properties
            builder.Property(x => x.ShowId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.ShowDate)
                   .IsRequired();

            builder.Property(x => x.StartTime)
                   .IsRequired();

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            //Relations
            builder.HasOne(x => x.Movie)
                   .WithMany(x => x.Shows)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Screen)
                   .WithMany(x => x.Shows)
                   .HasForeignKey(x => x.ScreenId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Bookings)
                   .WithOne(x => x.Show)
                   .HasForeignKey(x => x.ShowId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
