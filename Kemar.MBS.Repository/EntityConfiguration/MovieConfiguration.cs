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

            builder.Property(x => x.MovieId)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(1000);

            builder.Property(x => x.Category)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Language)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.DurationInMinutes)
                   .IsRequired();

            builder.Property(x => x.ReleaseDate)
                   .IsRequired();

            builder.Property(x => x.PosterUrl)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(x => x.BannerUrl)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(x => x.ThumbnailUrl)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(x => x.TrailerUrl)
                   .HasMaxLength(300)
                   .IsRequired(false);

            builder.Property(x => x.GalleryImages)
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(x => x.CastImages)
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(x => x.Director)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(x => x.Cast)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.Property(x => x.CensorRating)
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(x => x.ImdbRating)
                   .IsRequired(false);

            builder.Property(x => x.LikesPercentage)
                   .IsRequired(false);

            builder.HasMany(x => x.Shows)
                   .WithOne(x => x.Movie)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
