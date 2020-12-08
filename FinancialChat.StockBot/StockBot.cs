namespace FinancialChat.StockBot
{
    /// <summary>
    /// Bot API that receives a stock code and attempts to get stock quote using Stooq external service.
    /// </summary>
    public class StockBot : IStockBot
    {
        private string _stooqBaseUrl;

        public StockBot(string stooqBaseUrl)
        {
            _stooqBaseUrl = stooqBaseUrl;
        }

        public string GetStockQuote(string stockCode)
        {
            var stooqHelper = new StooqHelper<StockReportModel>();
            var stockReport = stooqHelper.GetStockReport<StockReportModel>(_stooqBaseUrl, stockCode).Result;
            var message = stockCode.ToUpper() + " quote is $" + stockReport.Close + " per share";
            return message;
        }
    }
}
