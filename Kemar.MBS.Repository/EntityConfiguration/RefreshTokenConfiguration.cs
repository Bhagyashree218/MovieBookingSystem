using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(rt => rt.RefreshTokenId);

            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(rt => rt.JwtId)
                .HasMaxLength(200);

            builder.Property(rt => rt.CreatedAt)
                .IsRequired();

            builder.Property(rt => rt.ExpiryDate)
                .IsRequired();
        }
    }
}
