using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace CarPrize.Test
{
    [TestFixture]
    public class CarPrizeTest
    {
        [SetUp]
        public void Init()
        {
            //Car.InitData();
        }

        [Test]
        [TestCase(6.0f, 217900f, "Europe", ExpectedResult = 34410768f)]
        [TestCase(1.5f, 19490f, "Japan", ExpectedResult = 1744121.12f)]
        [TestCase(3.6f, 36995f, "USA", ExpectedResult = 3700091.92f)]
        [TestCase(1.0f, 6000f, "China", ExpectedResult = 315840f)]
        public float CarPrize(float liter, float originalPrice, string region)
        {
            Car car = new Car()
            {
                Liter = liter,
                OriginalPrice = originalPrice,
                Region = region
            };
            return car.GetPrice();
        }
    }
}
