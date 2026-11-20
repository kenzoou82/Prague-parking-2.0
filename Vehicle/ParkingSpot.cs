using System;
using System.Collections.Generic;
using System.Text;

namespace Prague_parking_klasser
{
    public class ParkingSpot
    {
        public int SpotNumber { get; set; }
        public List<Vehicle> VehiclesInSpot { get; set; } = new List<Vehicle>();
        public int MaxSpace => 4;
        
        public int UsedSpace
        {
            get
            {
                int usedSpace = 0;
                foreach (var vehicle in VehiclesInSpot)
                {
                    usedSpace += vehicle.VehicleSize;
                }
                return usedSpace;
            }
        }
        public ParkingSpot(int spotNumber)
        {
            SpotNumber = spotNumber;
        }

    }
}
