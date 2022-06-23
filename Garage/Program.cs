﻿using Garage.Lib;
using System;

namespace Garage.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Car car = new Car("DR306NH", 2006, FuelType.Benzina, 1400, PortType.CinquePorte);
            Moto moto = new Moto("FG453HY", 2006, FuelType.Benzina, 1000, 1000);
            Van van = new Van("RT567UI", 2000, FuelType.Diesel, 1000, 10000);
            //FuelType ft = (FuelType)Enum.Parse(typeof(FuelType), "Benzina");
            Console.WriteLine(car);
            Console.WriteLine(moto);
            Console.WriteLine(van);

            IGarage garage = new Garage.Lib.Garage(5);

            Console.WriteLine(garage.Print());


            try
            {
                garage.InsertVehicle(car);
                garage.InsertVehicle(moto);
            } catch(PlaceAlreadyBusyException exc)
            {
                Console.WriteLine("Stai cercando di occupare una piazzola già occupata: " + exc.Message);
            }catch(GarageFullException exc1)
            {
                Console.WriteLine("Il garage è pieno. Si invita a riprovare più tardi: " + exc1.Message);
            } catch(Exception exc2)
            {
                Console.WriteLine("Eccezione generica: " + exc2.Message);
            }


            Vehicle vehicle = garage.ExtractVehicle(0);

            Console.ReadLine();
        }
    }
}
