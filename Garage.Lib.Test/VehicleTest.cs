using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Garage.Lib.Test
{
    public class VehicleTest
    {
        [Fact]
        public void CarWithWrongArgumentsTest()
        {
            Assert.Throws<ArgumentException>(() => new Car("DR12334242", 1920, FuelType.Gpl, 1000, PortType.TrePorte));
        }

        [Fact]
        public void CarWithWrongArgumentsTest1()
        {
            Assert.Throws<ArgumentException>(() => new Car("DR306NH", 1899, FuelType.Gpl, 1000, PortType.TrePorte));
        }
    }
}
