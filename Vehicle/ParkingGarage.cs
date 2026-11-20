using System;
using System.Collections.Generic;
using System.Text;

namespace Prague_parking_klasser
{
    public class ParkingGarage
    {
        public List<ParkingSpot> Spots { get; set; } = new List<ParkingSpot>();
        public ParkingGarage(int NumberOfSpots)
        {
            for (int i = 1; i <= NumberOfSpots; i++)
            {
                Spots.Add(new ParkingSpot(i));
            }
        }
        public int ParkVehicle(Vehicle vehicle)
        {
            foreach (var spot in Spots)
            {
                if (spot.UsedSpace + vehicle.VehicleSize <= spot.MaxSpace)
                {
                    spot.VehiclesInSpot.Add(vehicle);
                    return spot.SpotNumber;
                }
            }
            return 0;
        }
    }
}
