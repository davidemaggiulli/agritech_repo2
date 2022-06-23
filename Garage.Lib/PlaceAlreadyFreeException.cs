using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public class PlaceAlreadyFreeException : Exception
    {
        public PlaceAlreadyFreeException() : base("Posto già libero")
        {

        }
    }
}
