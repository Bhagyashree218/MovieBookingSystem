use Travel;

--1. Trips assigned to each driver.
SELECT d.Name AS DriverName, t.TripId, t.Source, t.Destination, t.Status
FROM Drivers d
JOIN Trips t ON d.DriverId = t.DriverId
ORDER BY d.Name, t.TripId;

--  2. Vehicles not assigned to any trip.
SELECT v.VehicleId, v.NumberPlate, v.Type, v.Status
FROM Vehicles v
LEFT JOIN Trips t ON v.VehicleId = t.VehicleId
WHERE t.VehicleId IS NULL;

--  3. Drivers with more than 2 trips.
SELECT d.Name AS DriverName, COUNT(t.TripId) AS TripCount
FROM Drivers d
JOIN Trips t ON d.DriverId = t.DriverId
GROUP BY d.DriverId, d.Name
HAVING COUNT(t.TripId) > 2;

