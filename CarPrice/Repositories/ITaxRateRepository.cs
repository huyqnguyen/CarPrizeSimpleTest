namespace CarPrize.Repositories
{
    public interface ITaxRateRepository
    {
        CarType GetCarType(float litter);
        RegionType GetRegionType(string regionName);
        int GetImportTaxRate(float litter, string regionName);
    }
}
