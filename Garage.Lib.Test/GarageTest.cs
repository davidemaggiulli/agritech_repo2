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

        [Fact]
        public void ExtractFreePlaceShouldReturnExceptionTest()
        {
            IGarage garage = new Garage(10);

            Car car = new Car("DR306NH", 1950, FuelType.Benzina, 1300, PortType.CinquePorte);
            garage.InsertVehicle(car);

            Assert.Throws<PlaceAlreadyFreeException>(() => garage.ExtractVehicle(1));
        }

        [Fact]
        public void ExtractFreePlaceShouldReturnExceptionTest2()
        {
            IGarage garage = new Garage(10);

            Car car = new Car("DR306NH", 1950, FuelType.Benzina, 1300, PortType.CinquePorte);
            garage.InsertVehicle(car);

            Assert.Throws<IndexOutOfRangeException>(() => garage.ExtractVehicle(11));
        }

        [Fact]
        public void ExtractVehicleOkTest()
        {
            IGarage garage = new Garage(10);

            Car car = new Car("DR306NH", 1950, FuelType.Benzina, 1300, PortType.CinquePorte);
            garage.InsertVehicle(car);

            Vehicle v = garage.ExtractVehicle(0);

            Assert.NotNull(v);
            Assert.Equal(car, v);
            Assert.True(v is Car);
        }

        [Fact]
        public void ExtractVehicleByPlateOkTest()
        {
            IGarage garage = new Garage(10);

            Car car = new Car("DR306NH", 1950, FuelType.Benzina, 1300, PortType.CinquePorte);
            Car car1 = new Car("DA123GH", 1950, FuelType.Benzina, 1300, PortType.CinquePorte);
            garage.InsertVehicle(car);
            garage.InsertVehicle(car1);

            Vehicle v = garage.ExtractVehicle("DA123GH");

            Assert.NotNull(v);
            Assert.Equal(car1, v);
            Assert.True(v is Car);
            Assert.Equal("DA123GH", v.Plate);
            Assert.True(garage.GetPlace(1).Status);
        }

    }
}
