using System;
using Xunit;

namespace Garage.Lib.Test
{
    public class GarageTest
    {
        [Fact]
        public void EmptyGarageTest()
        {
            IGarage garage = new Garage(10);

            Assert.NotNull(garage);
            for(int i = 0; i < 10;i++)
                Assert.True(garage.GetPlace(i).Status);
        }

        [Fact]
        public void InsertVehicleTest()
        {
            IGarage garage = new Garage(5);

            Car car = new Car("DR306NH", 1950, FuelType.Benzina, 1300, PortType.CinquePorte);
            garage.InsertVehicle(car);

            Assert.False(garage.GetPlace(0).Status);
            Assert.NotNull(garage.GetPlace(0).Vehicle);
            Assert.Equal(car, garage.GetPlace(0).Vehicle);
        }


        
    }
}
