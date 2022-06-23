using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class Moto : Vehicle
    {
        public Moto(string plate, int year, string fuelType, int displacement, int times) : base(plate, year, fuelType, displacement)
        {
            EngineTimes = times;
        }

        public int EngineTimes { get; }

        public override string ToString()
        {
            string temp = base.ToString();
            return $"Tipo: Moto\t{temp}\tTempi Motore: {EngineTimes}";
        }
    }
}
