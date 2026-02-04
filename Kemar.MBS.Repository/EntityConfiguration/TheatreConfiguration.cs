using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class TheatreConfiguration : IEntityTypeConfiguration<Theatre>
    {
        public void Configure(EntityTypeBuilder<Theatre> builder)
        {
            builder.HasKey(x => x.TheatreId);

            //Properties
            builder.Property(x => x.TheatreId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.TheatreName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Address)
                   .IsRequired()
                   .HasMaxLength(100);

            //Relations
            builder.HasOne(x => x.City)
                   .WithMany(x => x.Theatres)
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Screens)
                   .WithOne(x => x.Theatre)
                   .HasForeignKey(x => x.TheatreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
