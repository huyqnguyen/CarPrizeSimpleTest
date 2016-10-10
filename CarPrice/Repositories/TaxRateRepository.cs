using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPrize.Repositories
{
    public class TaxRateRepository : ITaxRateRepository
    {
        private Dictionary<float, CarType> _carType = new Dictionary<float, CarType>();
        private Dictionary<Tuple<RegionType, CarType>, int> _taxList = new Dictionary<Tuple<RegionType, CarType>, int>();
        private Dictionary<string, RegionType> _region = new Dictionary<string, RegionType>();

        public TaxRateRepository()
        {
            _carType.Add(2, CarType.Under2L);
            _carType.Add(5, CarType.From2LToUnder5L);
            _carType.Add(float.MaxValue, CarType.GreaterThan5L);

            _region.Add("Europe", RegionType.Europe);
            _region.Add("USA", RegionType.USA);
            _region.Add("Japan", RegionType.Japan);

            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.Europe, CarType.Under2L), 100);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.Europe, CarType.From2LToUnder5L), 120);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.Europe, CarType.GreaterThan5L), 200);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.USA, CarType.Under2L), 75);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.USA, CarType.From2LToUnder5L), 90);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.USA, CarType.GreaterThan5L), 150);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.Japan, CarType.Under2L), 70);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.Japan, CarType.From2LToUnder5L), 80);
            _taxList.Add(new Tuple<RegionType, CarType>(RegionType.Japan, CarType.GreaterThan5L), 135);
        }

        public CarType GetCarType(float litter)
        {
            return _carType.First(w => w.Key >= litter).Value;
        }

        public RegionType GetRegionType(string regionName)
        {
            try
            {
                return _region.First(w => w.Key == regionName).Value;
            }
            catch (Exception)
            {
                // For unsupported region, return null exception.
                return RegionType.Default;
            }
        }

        public int GetImportTaxRate(float litter, string regionName)
        {
            try
            {
                var regionType = GetRegionType(regionName);
                var carType = GetCarType(litter);
                return _taxList.First(w => w.Key.Item1 == regionType && w.Key.Item2 == carType).Value;
            }
            catch (Exception)
            {
                // Unsupported case, for example China Car not in the tax list.
                return 0;
            }
        }
    }
}
