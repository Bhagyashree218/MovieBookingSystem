using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class ScreenConfiguration : IEntityTypeConfiguration<Screen>
    {
        public void Configure(EntityTypeBuilder<Screen> builder)
        {
            builder.HasKey(x => x.ScreenId);

            //Properties
            builder.Property(x => x.ScreenId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.ScreenName)
                   .IsRequired()
                   .HasMaxLength(50);

            //Relations
            builder.HasOne(x => x.Theatre)
                   .WithMany(x => x.Screens)
                   .HasForeignKey(x => x.TheatreId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Seats)
                   .WithOne(x => x.Screen)
                   .HasForeignKey(x => x.ScreenId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Shows)
                   .WithOne(x => x.Screen)
                   .HasForeignKey(x => x.ScreenId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
