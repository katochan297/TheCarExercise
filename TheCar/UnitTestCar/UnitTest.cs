using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheCar;
using TheCar.Enum;
using TheCar.Service;


namespace UnitTestCar
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void Test_Benz_G65_Car()
        {
            var car = new Car
            {
                CarName = "Benz G65",
                Liter = 6.0f,
                OriginalPrice = 217900f,
                OriginalRegion = Region.Europe
            };
            var svc = new CarService();

            Assert.AreEqual(732144f, svc.CaculateEndUserPrice_USD(car));
            Assert.AreEqual(34410768f, svc.CaculateEndUserPrice_Pesos(car));
        }

        [TestMethod]
        public void Test_Honda_Jazz_Car()
        {
            var car = new Car
            {
                CarName = "Honda Jazz",
                Liter = 1.5f,
                OriginalPrice = 19490f,
                OriginalRegion = Region.Japan
            };
            var svc = new CarService();

            Assert.AreEqual(37108.96f, svc.CaculateEndUserPrice_USD(car));
            Assert.AreEqual(1744121.12f, svc.CaculateEndUserPrice_Pesos(car));
        }

        [TestMethod]
        public void Test_Jeep_Wrangler_Car()
        {
            var car = new Car
            {
                CarName = "Jeep wrangler",
                Liter = 3.6f,
                OriginalPrice = 36995f,
                OriginalRegion = Region.USA
            };
            var svc = new CarService();

            Assert.AreEqual(78725.36f, svc.CaculateEndUserPrice_USD(car));
            Assert.AreEqual(3700091.92f, svc.CaculateEndUserPrice_Pesos(car));
        }

        [TestMethod]
        public void Test_Chery_QQ_Car()
        {
            var car = new Car
            {
                CarName = "Chery QQ",
                Liter = 1.0f,
                OriginalPrice = 6000f,
                OriginalRegion = Region.Other
            };
            var svc = new CarService();

            Assert.AreEqual(6720f, svc.CaculateEndUserPrice_USD(car));
            Assert.AreEqual(315840f, svc.CaculateEndUserPrice_Pesos(car));
        }


    }
}
