using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class Garage : IGarage
    {
        private Place[] places;

        public Garage(int n)
        {
            places = new Place[n];
            for(int i = 0; i < n;i++)
                places[i] = new Place();
        }

        public Vehicle ExtractVehicle(int placeNumber)
        {
            if (placeNumber < 0 || placeNumber >= places.Length)
                throw new IndexOutOfRangeException();

            var place = places[placeNumber];

            return place.SetFree();

        }

        public Vehicle ExtractVehicle(string plate)
        {
            throw new NotImplementedException();
        }

        public Place GetPlace(int pos)
        {
            if(pos >= 0 && pos < places.Length)
                return places[pos];
            throw new IndexOutOfRangeException();
        }

        public int InsertVehicle(Vehicle vehicle)
        {
            for(int i = 0; i < places.Length; i++)
            {
                if (places[i].Status)
                {
                    //Piazzola libera --> Possiamo utilizzarla

                    //Occupa il posto
                    places[i].SetBusy(vehicle);
                    return i;
                }
            }
            throw new GarageFullException();
        }

        public string Print()
        {
            string s = string.Empty;
            for(int i = 0; i < places.Length; i++)
            {
                if (places[i].Status)
                    s = s + $"{i}: LIBERO\n";
                else
                    s = s + $"{i}: OCCUPATO ({places[i].Date}): {places[i].Vehicle}";
            }
            return s;
        }
    }
}
