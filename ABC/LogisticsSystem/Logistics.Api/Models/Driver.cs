namespace Logistics.Api.Models
{
    public class Driver
    {
        // Primary key
        public int DriverId { get; set; }

        // Basic driver details
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }

        // Experience helps with assigning critical routes
        public int ExperienceYears { get; set; }

        // Availability flag to assign new trips
        public bool IsAvailable { get; set; } = true;

        // Navigation property — connects to the Trip table (1 driver → many trips).
        public ICollection<Trip>? Trips { get; set; }
    }
}
