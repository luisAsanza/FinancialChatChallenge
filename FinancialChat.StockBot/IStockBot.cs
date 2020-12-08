namespace FinancialChat.StockBot
{
    /// <summary>
    /// Contract interface for stock bot (can be used for unit testing)
    /// </summary>
    public interface IStockBot
    {
        string GetStockQuote(string stockCode);
    }
}
