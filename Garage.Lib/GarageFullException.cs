using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class GarageFullException : Exception
    {
        public GarageFullException() : base ("Garage pieno")
        {

        }
    }
}
