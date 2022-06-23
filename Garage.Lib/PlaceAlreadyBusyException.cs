using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class PlaceAlreadyBusyException : Exception
    {
        public PlaceAlreadyBusyException() : base("Posto già occupato")
        {

        }
    }
}
