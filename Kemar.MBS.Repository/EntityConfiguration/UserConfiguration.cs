using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            //Properties
            builder.Property(x => x.UserId)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.UserEmail)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            //Relations
            builder.HasMany(x => x.Bookings)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
