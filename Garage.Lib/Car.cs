using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class Car : Vehicle
    {
        public Car(string plate, int year, FuelType fuelType, int displacement, PortType ports) : base(plate, year, fuelType, displacement)
        {
            PortsNum = ports;
        }

        public PortType PortsNum { get; }

        public override string ToString()
        {
            string temp = base.ToString();
            return $"Tipo: Auto\t{temp}\tNum Porte:{(int)PortsNum}";
        }

    }
}
