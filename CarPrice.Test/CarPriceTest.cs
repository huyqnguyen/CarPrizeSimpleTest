using NUnit.Framework;

namespace CarPrize.Test
{
    [TestFixture]
    public class CarPriceTest
    {
        [Test]
        [TestCase(6.0f, 217900f, "Europe", ExpectedResult = 34410768f)]
        [TestCase(1.5f, 19490f, "Japan", ExpectedResult = 1744121.12f)]
        [TestCase(3.6f, 36995f, "USA", ExpectedResult = 3700091.92f)]
        [TestCase(1.0f, 6000f, "China", ExpectedResult = Assert.Throws<>)]
        public float CarPrize(float liter, float originalPrice, string region)
        {
            ICar car = new Car()
            {
                Liter = liter,
                OriginalPrice = originalPrice,
                Region = region
            };
            return car.GetPrice();
        }
    }
}
