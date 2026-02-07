using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.Api.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        // Foreign Key relationships
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        // Trip details
        public string Source { get; set; }
        public string Destination { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // Trip status: "Active", "Completed", "Pending"
        public string Status { get; set; }

        // Navigation properties (? -  make nullable)
        public Driver? Driver { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
