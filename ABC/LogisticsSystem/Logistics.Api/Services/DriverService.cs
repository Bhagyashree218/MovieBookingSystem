using Logistics.Api.Data;
using Logistics.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Services
{
    public class DriverService
    {
        private readonly AppDbContext _context;

        public DriverService(AppDbContext context)
        {
            _context = context;
        }

        //  Get all drivers
        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        //  Get a single driver by ID
        public async Task<Driver?> GetDriverByIdAsync(int id)
        {
            return await _context.Drivers
                .Include(d => d.Trips) // include trips if needed
                .FirstOrDefaultAsync(d => d.DriverId == id);
        }

        //  Add a new driver
        public async Task<Driver> AddDriverAsync(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        //  Update driver
        public async Task<bool> UpdateDriverAsync(int id, Driver driver)
        {
            var existing = await _context.Drivers.FindAsync(id);
            if (existing == null)
                return false;

            existing.Name = driver.Name;
            existing.LicenseNumber = driver.LicenseNumber;
            existing.Phone = driver.Phone;
            existing.ExperienceYears = driver.ExperienceYears;
            existing.IsAvailable = driver.IsAvailable;

            await _context.SaveChangesAsync();
            return true;
        }

        //  Delete driver
        public async Task<bool> DeleteDriverAsync(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
                return false;

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return true;
        }

        //  Get only available drivers
        public async Task<IEnumerable<Driver>> GetAvailableDriversAsync()
        {
            return await _context.Drivers
                .Where(d => d.IsAvailable)
                .ToListAsync();
        }
    }
}
