using Logistics.Api.Data;
using Logistics.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Api.Services
{
    public class VehicleService
    {
        private readonly AppDbContext _context;

        public VehicleService(AppDbContext context)
        {
            _context = context;
        }

        //  Get all vehicles
        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        //  Get a single vehicle by ID
        public async Task<Vehicle?> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles
                .Include(v => v.Trips)
                .FirstOrDefaultAsync(v => v.VehicleId == id);
        }

        //  Add new vehicle
        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        //  Update vehicle
        public async Task<bool> UpdateVehicleAsync(int id, Vehicle vehicle)
        {
            var existing = await _context.Vehicles.FindAsync(id);
            if (existing == null)
                return false;

            existing.NumberPlate = vehicle.NumberPlate;
            existing.Type = vehicle.Type;
            existing.Capacity = vehicle.Capacity;
            existing.Status = vehicle.Status;
            existing.IsAvailable = vehicle.IsAvailable;

            await _context.SaveChangesAsync();
            return true;
        }

        //  Delete vehicle
        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return false;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        //  Get available vehicles
        public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
        {
            return await _context.Vehicles
                .Where(v => v.IsAvailable)
                .ToListAsync();
        }
    }
}
