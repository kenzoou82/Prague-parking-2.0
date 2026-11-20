using System;
using System.Collections.Generic;
using System.Text;

namespace Prague_parking_klasser
{
    public class Car : Vehicle
    {
        public override int VehicleSize => 4;
        public Car(string regNumber) : base(regNumber)
        {
            
        }
    }
}
