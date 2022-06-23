namespace Garage.Lib
{
    public abstract class Vehicle
    {
        public Vehicle(string plate, int year, string fuelType, int displacement)
        {
            Plate = plate; 
            Year = year;
            FuelType = fuelType;
            Displacement = displacement;
        }
        public string Plate { get; }

        public int Year { get; }

        public string FuelType { get; }

        public int Displacement { get; }

        public override string ToString()
        {
            return $"Targa: {Plate}\tAnno Imm.:{Year}\tCilindrata:{Displacement}\tAlimentazione: {FuelType}";
        }
    }
}