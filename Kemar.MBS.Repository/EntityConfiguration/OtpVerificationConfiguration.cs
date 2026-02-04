using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class OtpVerificationConfiguration : IEntityTypeConfiguration<OtpVerification>
    {
        public void Configure(EntityTypeBuilder<OtpVerification> builder)
        {
            builder.HasKey(o => o.OtpId);

            builder.Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(o => o.OtpHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(o => o.CreatedAt)
                .IsRequired();

            builder.Property(o => o.ExpiryTime)
                .IsRequired();
        }
    }
}
