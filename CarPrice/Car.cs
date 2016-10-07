using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPrize
{
    public class Car : ICar
    {
        public Car()
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

        private Dictionary<float, CarType> _carType = new Dictionary<float, CarType>();
        private Dictionary<Tuple<RegionType, CarType>, int> _taxList = new Dictionary<Tuple<RegionType, CarType>, int>();
        private Dictionary<string, RegionType> _region = new Dictionary<string, RegionType>();

        private const int PesoExchangRate = 47;
        public string Region { get; set; }
        public float Liter { get; set; }

        public float OriginalPrice { get; set; }
        private float ImportTax
        {
            get
            {
                return this.OriginalPrice * this.ImportTaxRate / 100;
            }
            set { }
        }

        private int ImportTaxRate
        {
            get
            {
                try
                {
                    //Preparing data for mapping.
                    var carType = _carType.First(w => w.Key >= this.Liter);
                    var regionType = _region.First(w => w.Key == this.Region);

                    // return tax rate by mapping region type and car type
                    return _taxList.FirstOrDefault(w => w.Key.Item1 == regionType.Value && w.Key.Item2 == carType.Value).Value;
                }
                catch (Exception)
                {
                    // Unlisted region type and car type.
                    return 0;
                }
            }
        }
        private float VAT
        {
            get
            {
                return (this.OriginalPrice + this.ImportTax) * 12 / 100;
            }
            set { }
        }
        public float GetPrice()
        {
            return (this.OriginalPrice + this.ImportTax + this.VAT)* PesoExchangRate; 
        }
    }
}
