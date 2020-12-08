
namespace FinancialChat.StockBot
{
    /// <summary>
    /// Model to map stooq csv data to c# object
    /// </summary>
    internal class StockReportModel
    {
        public string Symbol { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public string Volume { get; set; }
    }
}
