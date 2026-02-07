namespace Logistics.Api.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        // Identification number (unique)
        public string NumberPlate { get; set; }

        // Type e.g. Truck, Van, Mini, etc.
        public string Type { get; set; }

        // How much load vehicle can carry
        public int Capacity { get; set; }

        // Status - Active, In Maintenance, etc.
        public string Status { get; set; }

        // If available for trips
        public bool IsAvailable { get; set; } = true;

        //Navigation property — one vehicle can have many trips.
        public ICollection<Trip>? Trips { get; set; }
    }
}
