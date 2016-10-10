using CarPrize.Repositories;
using NUnit.Framework;
using System;

namespace CarPrize.Test
{
    [TestFixture]
    public class TaxRepositoryTest
    {
        [Test]
        [TestCase(1.0f, ExpectedResult = CarType.Under2L)]
        [TestCase(1.99999f, ExpectedResult = CarType.Under2L)]
        [TestCase(0.0f, ExpectedResult = CarType.Under2L)]
        [TestCase(2.0f, ExpectedResult = CarType.Under2L)]
        [TestCase(2.00001f, ExpectedResult = CarType.From2LToUnder5L)]
        [TestCase(5.0f, ExpectedResult = CarType.From2LToUnder5L)]
        [TestCase(3.0f, ExpectedResult = CarType.From2LToUnder5L)]
        [TestCase(5.00001f, ExpectedResult = CarType.GreaterThan5L)]
        [TestCase(10.0f, ExpectedResult = CarType.GreaterThan5L)]
        public CarType TestGetCarType(float litter)
        {
            ITaxRateRepository taxrateRepository = new TaxRateRepository();
            return taxrateRepository.GetCarType(litter);
        }

        [Test]
        [TestCase("Europe", ExpectedResult = RegionType.Europe)]
        [TestCase("USA", ExpectedResult = RegionType.USA)]
        [TestCase("Japan", ExpectedResult = RegionType.Japan)]
        [TestCase("China", ExpectedResult = RegionType.Default)]
        [TestCase("VietNam", ExpectedResult = RegionType.Default)]
        public RegionType TestGetRegionType(string region)
        {
            ITaxRateRepository taxrateRepository = new TaxRateRepository();
            return taxrateRepository.GetRegionType(region);
        }

        [Test]
        [TestCase(1.0f, "Europe", ExpectedResult = 100)]
        [TestCase(1.0f, "USA", ExpectedResult = 75)]
        [TestCase(1.0f, "Japan", ExpectedResult = 70)]
        [TestCase(1.99999f, "Europe", ExpectedResult = 100)]
        [TestCase(1.99999f, "USA", ExpectedResult = 75)]
        [TestCase(1.99999f, "Japan", ExpectedResult = 70)]
        [TestCase(3.0f, "Europe", ExpectedResult = 120)]
        [TestCase(3.0f, "USA", ExpectedResult = 90)]
        [TestCase(3.0f, "Japan", ExpectedResult = 80)]
        [TestCase(2.00001f, "Europe", ExpectedResult = 120)]
        [TestCase(2.00001f, "USA", ExpectedResult = 90)]
        [TestCase(2.00001f, "Japan", ExpectedResult = 80)]
        [TestCase(5.0f, "Europe", ExpectedResult = 120)]
        [TestCase(5.0f, "USA", ExpectedResult = 90)]
        [TestCase(5.0f, "Japan", ExpectedResult = 80)]
        [TestCase(6.0f, "Europe", ExpectedResult = 200)]
        [TestCase(6.0f, "USA", ExpectedResult = 150)]
        [TestCase(6.0f, "Japan", ExpectedResult = 135)]
        [TestCase(5.00001f, "Europe", ExpectedResult = 200)]
        [TestCase(5.00001f, "USA", ExpectedResult = 150)]
        [TestCase(5.00001f, "Japan", ExpectedResult = 135)]
        public int TestGetTaxRate(float litter, string region)
        {
            ITaxRateRepository taxrateRepository = new TaxRateRepository();
            return taxrateRepository.GetImportTaxRate(litter, region);
        }
    }
}
