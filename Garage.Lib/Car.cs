using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class Car : Vehicle
    {
        public Car(string plate, int year, string fuelType, int displacement, int ports) : base(plate, year, fuelType, displacement)
        {
            PortsNum = ports;
        }

        public int PortsNum { get; }

        public override string ToString()
        {
            string temp = base.ToString();
            return $"Tipo: Auto\t{temp}\tNum Porte:{PortsNum}";
        }

    }
}
