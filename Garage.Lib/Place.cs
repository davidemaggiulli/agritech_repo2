using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class Place
    {
        public Place()
        {
            Status = true;
            Vehicle = null;
        }
        public bool Status { get; private set; }

        public DateTime Date { get; private set; }

        public Vehicle Vehicle { get; private set; }

        public void SetBusy(Vehicle vehicle)
        {
            if (!Status)
                throw new PlaceAlreadyBusyException();

            Status = false;
            Date = DateTime.Now;
            Vehicle = vehicle;
        }

        public Vehicle SetFree()
        {
            if (Status)
                throw new PlaceAlreadyFreeException();
            Status = true;
            Date = DateTime.MinValue;
            Vehicle temp = Vehicle;
            Vehicle = null;
            return temp;
        }
    }
}
