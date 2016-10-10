using CarPrize.Repositories;

namespace CarPrize
{
    public class Car : ICar
    {
        private TaxRateRepository _taxRateRepository;
        public Car()
        {
            _taxRateRepository = new TaxRateRepository();
        }
        private const int PesoExchangRate = 47;
        public string Region { get; set; }
        public float Liter { get; set; }
        public float OriginalPrice { get; set; }

        private float ImportTax
        {
            get
            {
                return OriginalPrice * ImportTaxRate / 100;
            }
        }

        private int ImportTaxRate
        {
            get
            {
                return _taxRateRepository.GetImportTaxRate(Liter, Region);
            }
        }
        private float VAT
        {
            get
            {
                return (OriginalPrice + ImportTax) * 12 / 100;
            }
        }
        public float GetPrice()
        {
            return (OriginalPrice + ImportTax + VAT) * PesoExchangRate;
        }
    }
}
