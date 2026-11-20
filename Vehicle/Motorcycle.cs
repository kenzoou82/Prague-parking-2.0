using System;
using System.Collections.Generic;
using System.Text;

namespace Prague_parking_klasser
{
    public class Motorcycle : Vehicle
    {
        public override int VehicleSize => 2;
        public Motorcycle(string regNumber) : base(regNumber)
        {
        }
    }
}
