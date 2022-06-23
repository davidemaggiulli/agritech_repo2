using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class Van : Vehicle
    {
        public Van(string plate, int year, string fuelType, int displacement, int capacity) : base(plate, year, fuelType, displacement)
        {
            Capacity = capacity;
        }

        public int Capacity { get; }

        public override string ToString()
        {
            string temp = base.ToString();
            return $"Tipo: Furgone\t{temp}\tCapacità: {Capacity}";
        }
    }
}
