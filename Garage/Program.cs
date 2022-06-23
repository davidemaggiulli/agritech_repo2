using Garage.Lib;
using System;

namespace Garage.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Car car = new Car("DR306NH", 2006, "Diesel", 1400, 5);
            Moto moto = new Moto("FG453HY", 2006, "Benzina", 1000, 1000);
            Van van = new Van("RT567UI", 2000, "Diesedfsdl", 1000, 10000);

            Console.WriteLine(car);
            Console.WriteLine(moto);
            Console.WriteLine(van);

            Console.ReadLine();
        }
    }
}
