using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemar.MBS.Repository.EntityConfiguration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            // Primary Key
            builder.HasKey(x => x.AdminId);

            //Properties
            builder.Property(x => x.AdminId)
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.AdminName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.AdminEmail)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
