using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kemar.MBS.Repository.Context
{
    public class KemarMBSDbContext : DbContext
    {
        public KemarMBSDbContext(DbContextOptions<KemarMBSDbContext> options): base(options) { }

        //DB SETS
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSeat> BookingSeats { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OtpVerification> OtpVerifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies all configuration classes automatically
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
