using System;
namespace Garage.Lib
{
    public abstract class Vehicle
    {
        public Vehicle(string plate, int year, FuelType fuelType, int displacement)
        {
            if (plate.Length != 7)
                throw new ArgumentException("Targa non valida");
            if (year < 1900 || year > DateTime.Now.Year)
                throw new ArgumentException("Anno di immatricolazione non valido");
            if (displacement > 800 && displacement < 3000 && displacement % 50 != 0)
                throw new ArgumentException("Cilindrata non valida");

            Plate = plate; 
            Year = year;
            FuelType = fuelType;
            Displacement = displacement;
        }
        public string Plate { get; }

        public int Year { get; }

        public FuelType FuelType { get; }

        public int Displacement { get; }

        public override string ToString()
        {
            return $"Targa: {Plate}\tAnno Imm.:{Year}\tCilindrata:{Displacement}\tAlimentazione: {FuelType}";
        }
    }
}