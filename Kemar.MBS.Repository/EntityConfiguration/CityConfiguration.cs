using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.CityId);

            //Properties
            builder.Property(x => x.CityId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.CityName)
                   .IsRequired()
                   .HasMaxLength(50);

            //Relations
            builder.HasMany(x => x.Theatres)
                   .WithOne(x => x.City)
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
