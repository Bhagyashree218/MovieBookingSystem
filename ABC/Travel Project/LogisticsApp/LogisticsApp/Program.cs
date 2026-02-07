using System;
using System.Collections.Generic;
using System.Linq;

namespace LogisticsApp
{
    // 1️ Driver Class

    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperienceYears { get; set; }

        public Driver(int id, string name, int experienceYears)
        {
            Id = id;
            Name = name;
            ExperienceYears = experienceYears;
        }
    }

    
    // 2️ Vehicle (Base Class)
   
    public class Vehicle
    {
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public string Type { get; set; }

        public Vehicle(int id, string numberPlate, string type)
        {
            Id = id;
            NumberPlate = numberPlate;
            Type = type;
        }

        public override string ToString() => $"{Type} ({NumberPlate})";
    }

    
    // 4️ Inheritance → Truck & Van
    
    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }

        public Truck(int id, string numberPlate, int loadCapacity)
            : base(id, numberPlate, "Truck")
        {
            LoadCapacity = loadCapacity;
        }
    }

    public class Van : Vehicle
    {
        public int StorageVolume { get; set; }

        public Van(int id, string numberPlate, int storageVolume)
            : base(id, numberPlate, "Van")
        {
            StorageVolume = storageVolume;
        }
    }

    
    // 3️ Trip Class
    
    public class Trip
    {
        public int Id { get; set; }
        public Driver Driver { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }

        public void AssignDriver(Driver driver) => Driver = driver;
        public void AssignVehicle(Vehicle vehicle) => Vehicle = vehicle;

        public double DurationHours => (EndTime - StartTime).TotalHours;

        public override string ToString()
        {
            return $"Trip {Id}: {Driver?.Name} driving {Vehicle?.ToString()} | " +
                   $"Status: {Status} | Duration: {DurationHours:F1} hrs";
        }
    }

    
    // MAIN PROGRAM
    
    class Program
    {
        static void Main(string[] args)
        {
            // Drivers
            List<Driver> drivers = new List<Driver>
            {
                new Driver(1, "Alice Kumar", 5),
                new Driver(2, "Bob Patel", 3),
                new Driver(3, "Carol Singh", 7),
                new Driver(4, "David Roy", 2),
                new Driver(5, "Eva Menon", 8)
            };

            // Vehicles
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Truck(1, "AB-12-1234", 1000),
                new Van(2, "BC-23-2345", 600),
                new Truck(3, "CD-34-3456", 1200),
                new Van(4, "DE-45-4567", 500)
            };

            // Trips
            List<Trip> trips = new List<Trip>
            {
                new Trip { Id = 1, StartTime = DateTime.Now.AddHours(-6), EndTime = DateTime.Now, Status = "Completed" },
                new Trip { Id = 2, StartTime = DateTime.Now.AddHours(-3), EndTime = DateTime.Now, Status = "InProgress" },
                new Trip { Id = 3, StartTime = DateTime.Now.AddHours(-10), EndTime = DateTime.Now.AddHours(-4), Status = "Completed" },
                new Trip { Id = 4, StartTime = DateTime.Now.AddHours(-7), EndTime = DateTime.Now.AddHours(-1), Status = "InProgress" }
            };

            // Assigning Drivers & Vehicles
            trips[0].AssignDriver(drivers[0]);
            trips[0].AssignVehicle(vehicles[0]);

            trips[1].AssignDriver(drivers[1]);
            trips[1].AssignVehicle(vehicles[1]);

            trips[2].AssignDriver(drivers[2]);
            trips[2].AssignVehicle(vehicles[2]);

            trips[3].AssignDriver(drivers[3]);
            trips[3].AssignVehicle(vehicles[3]);

            
            // OUTPUT SECTION

            Console.WriteLine("===  Active Trips (Status = 'InProgress') ===");
            var activeTrips = trips.Where(t => t.Status == "InProgress");
            foreach (var trip in activeTrips)
                Console.WriteLine(trip);

            Console.WriteLine("\n===  Trips Exceeding 5 Hours ===");
            var longTrips = trips.Where(t => t.DurationHours > 5);
            foreach (var trip in longTrips)
                Console.WriteLine(trip);

            Console.WriteLine("\n===  Drivers with >5 Years Experience ===");
            var experiencedDrivers = drivers.Where(d => d.ExperienceYears > 5);
            foreach (var driver in experiencedDrivers)
                Console.WriteLine($"{driver.Name} ({driver.ExperienceYears} years)");

        }
    }
}
