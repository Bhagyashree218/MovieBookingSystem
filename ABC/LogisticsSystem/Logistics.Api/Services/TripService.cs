using Logistics.Api.Data;
using Logistics.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Services
{
    public class TripService
    {
        private readonly AppDbContext _context;

        public TripService(AppDbContext context)
        {
            _context = context;
        }

        //  Get all trips
        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips
                .Include(t => t.Driver)
                .Include(t => t.Vehicle)
                .ToListAsync();
        }

        //  Create a new trip (assign driver + vehicle)
        public async Task<Trip?> CreateTripAsync(Trip trip)
        {
            var driver = await _context.Drivers.FindAsync(trip.DriverId);
            var vehicle = await _context.Vehicles.FindAsync(trip.VehicleId);

            if (driver == null || vehicle == null)
                return null; // Either driver or vehicle not found

            if (!driver.IsAvailable || !vehicle.IsAvailable)
                return null; // Can't assign if already in use

            // Set initial details
            trip.StartTime = DateTime.Now;
            trip.Status = "Active";

            // Mark both unavailable
            driver.IsAvailable = false;
            vehicle.IsAvailable = false;

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        //  Complete trip
        public async Task<bool> CompleteTripAsync(int tripId)
        {
            var trip = await _context.Trips
                .Include(t => t.Driver)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(t => t.TripId == tripId);

            if (trip == null)
                return false;

            trip.EndTime = DateTime.Now;
            trip.Status = "Completed";

            // Free up driver and vehicle
            if (trip.Driver != null) trip.Driver.IsAvailable = true;
            if (trip.Vehicle != null) trip.Vehicle.IsAvailable = true;

            await _context.SaveChangesAsync();
            return true;
        }

        //  Trips longer than 8 hours
        public async Task<IEnumerable<Trip>> GetLongTripsAsync()
        {
            return await _context.Trips
                .Where(t => t.EndTime.HasValue &&
                            EF.Functions.DateDiffHour(t.StartTime, t.EndTime.Value) > 8)
                .Include(t => t.Driver)
                .Include(t => t.Vehicle)
                .ToListAsync();
        }

        //  Get all trips by a driver
        public async Task<IEnumerable<Trip>> GetTripsByDriverAsync(int driverId)
        {
            return await _context.Trips
                .Where(t => t.DriverId == driverId)
                .Include(t => t.Vehicle)
                .ToListAsync();
        }
    }
}
