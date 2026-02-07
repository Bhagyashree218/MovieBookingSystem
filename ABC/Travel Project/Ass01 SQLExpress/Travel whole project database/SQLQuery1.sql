IF DB_ID('LogisticsDB') IS NULL
BEGIN
    CREATE DATABASE LogisticsDB;
END
GO

USE LogisticsDB;
GO

-- 2) Create tables (normalized: Drivers, Vehicles, Trips)
IF OBJECT_ID('dbo.Drivers') IS NOT NULL DROP TABLE dbo.Drivers;
IF OBJECT_ID('dbo.Vehicles') IS NOT NULL DROP TABLE dbo.Vehicles;
IF OBJECT_ID('dbo.Trips') IS NOT NULL DROP TABLE dbo.Trips;
GO

CREATE TABLE Drivers (
    DriverId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    LicenseNumber NVARCHAR(50) NOT NULL UNIQUE,
    Phone NVARCHAR(30),
    ExperienceYears INT CHECK (ExperienceYears >= 0)
);

CREATE TABLE Vehicles (
    VehicleId INT IDENTITY(1,1) PRIMARY KEY,
    NumberPlate NVARCHAR(50) NOT NULL UNIQUE,
    Type NVARCHAR(50) NOT NULL,           -- e.g., Truck, Van
    Capacity INT NOT NULL,                -- numeric capacity units
    Status NVARCHAR(50) NOT NULL          -- e.g., Available, Maintenance, InService
);


CREATE TABLE Trips (
    TripId INT IDENTITY(1,1) PRIMARY KEY,
    VehicleId INT NOT NULL,
    DriverId INT NOT NULL,
    Source NVARCHAR(200) NOT NULL,
    Destination NVARCHAR(200) NOT NULL,
    StartTime DATETIME2 NOT NULL,
    EndTime DATETIME2 NULL,
    Status NVARCHAR(50) NOT NULL,         -- e.g., Planned, InProgress, Completed, Cancelled
    CONSTRAINT FK_Trips_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId),
    CONSTRAINT FK_Trips_Drivers FOREIGN KEY (DriverId) REFERENCES Drivers(DriverId)
);
GO

-- 3) Insert 5 drivers
INSERT INTO Drivers (Name, LicenseNumber, Phone, ExperienceYears) VALUES
('Alice Kumar', 'LIC-A1001', '9876543210', 5),
('Bob Patel',   'LIC-B2002', '9876501234', 3),
('Carol Singh', 'LIC-C3003', '9812345678', 1),
('David Roy',   'LIC-D4004', '9800123456', 7),
('Eva Menon',   'LIC-E5005', '9899988776', 2);
GO

-- 4) Insert 5 vehicles
INSERT INTO Vehicles (NumberPlate, Type, Capacity, Status) VALUES
('AB-12-1234', 'Truck', 1000, 'Available'),
('BC-23-2345', 'Van', 500, 'Available'),
('CD-34-3456', 'Truck', 1200, 'Maintenance'),
('DE-45-4567', 'Van', 600, 'Available'),
('EF-56-5678', 'Truck', 800, 'Available');   -- this one will be left unassigned in the sample
GO

-- 5) Insert 5 trips
INSERT INTO Trips (VehicleId, DriverId, Source, Destination, StartTime, EndTime, Status) VALUES
(1, 1, 'Warehouse A', 'City Center',    '2025-10-01 08:00', '2025-10-01 11:30', 'Completed'),
(1, 1, 'City Center',  'Distribution Hub','2025-10-02 09:00', '2025-10-02 12:00', 'Completed'),
(2, 1, 'Distribution Hub','Branch X',    '2025-10-03 07:30', '2025-10-03 10:00', 'Completed'),
(3, 2, 'Warehouse B', 'Retail Park',    '2025-10-04 10:00', '2025-10-04 14:00', 'Completed'),
(4, 2, 'Retail Park',  'Warehouse B',   '2025-10-05 09:00', '2025-10-05 12:30', 'Planned');
GO

-- Query 1: List trips assigned to each driver (driver + their trips)
SELECT
    d.DriverId,
    d.Name AS DriverName,
    t.TripId,
    t.VehicleId,
    t.Source,
    t.Destination,
    t.StartTime,
    t.EndTime,
    t.Status
FROM Drivers d
JOIN Trips t ON d.DriverId = t.DriverId
ORDER BY d.DriverId, t.StartTime;
GO

-- Query 2: Find vehicles not assigned to any trip
SELECT
    v.VehicleId,
    v.NumberPlate,
    v.Type,
    v.Capacity,
    v.Status
FROM Vehicles v
LEFT JOIN Trips t ON v.VehicleId = t.VehicleId
WHERE t.VehicleId IS NULL;
GO

-- Query 3: Show drivers with more than 2 trips
SELECT
    d.DriverId,
    d.Name,
    COUNT(t.TripId) AS TripCount
FROM Drivers d
JOIN Trips t ON d.DriverId = t.DriverId
GROUP BY d.DriverId, d.Name
HAVING COUNT(t.TripId) > 2;
GO

--4.Include drivers who have zero trips (LEFT JOIN):

SELECT d.DriverId, d.Name, COUNT(t.TripId) AS TripCount
FROM Drivers d
LEFT JOIN Trips t ON d.DriverId = t.DriverId
GROUP BY d.DriverId, d.Name
ORDER BY TripCount DESC;

--5.Show vehicles and number of trips (including 0):

SELECT v.VehicleId, v.NumberPlate, COUNT(t.TripId) AS TripCount
FROM Vehicles v
LEFT JOIN Trips t ON v.VehicleId = t.VehicleId
GROUP BY v.VehicleId, v.NumberPlate
ORDER BY TripCount DESC;


Use LogisticsDB;

SELECT * FROM Drivers;
SELECT* FROM Vehicles;
SELECT * FROM Trips;


USE TripDB;

SELECT * FROM Drivers;
SELECT * FROM Vehicles;
SELECT * FROM Trips;

INSERT INTO Vehicles (NumberPlate, Type, Capacity, Status)
VALUES
  ('ABC123', 'Truck', 1000, 'Active'),
  ('DEF456', 'Car', 5, 'Active'),
  ('GHI789', 'Van', 12, 'Inactive'),
  ('JKL012', 'Bus', 50, 'Active'),
  ('MNO345', 'Truck', 1500, 'Inactive'),
  ('PQR678', 'Car', 4, 'Active'),
  ('STU901', 'Van', 10, 'Active'),
  ('VWX234', 'Bus', 45, 'Inactive'),
  ('YZA567', 'Truck', 1200, 'Active'),
  ('BCD890', 'Car', 5, 'Active');
