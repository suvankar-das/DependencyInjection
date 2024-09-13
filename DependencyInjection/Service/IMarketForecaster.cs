namespace DependencyInjection.Service
{
    public interface IMarketForecaster
    {
        MarketResult GetMarketPrediction();
    }
}