namespace DependencyInjection.Service
{
    public class MarketForecaster : IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // Assume API call and complex calculation , I got maket up signal
            return new MarketResult()
            {
                MarketCondition = Models.MarketCondition.StableUp
            };
        }
    }
}
