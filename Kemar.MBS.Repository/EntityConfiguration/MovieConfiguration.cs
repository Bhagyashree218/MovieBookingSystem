using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.MovieId);

            //Properties
            builder.Property(x => x.MovieId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.Genre)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Language)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.DurationInMinutes)
                   .IsRequired();

            builder.Property(x => x.PosterUrl)
                   .HasMaxLength(100);

            builder.Property(x => x.ReleaseDate)
                   .IsRequired();

            //Relations
            builder.HasMany(x => x.Shows)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
