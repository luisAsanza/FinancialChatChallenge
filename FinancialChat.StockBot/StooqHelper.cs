using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;

namespace FinancialChat.StockBot
{
    /// <summary>
    /// Helps to connect to stooq url to attempt to get a CSV file with stock report based on given Url and Stock Code
    /// </summary>
    internal class StooqHelper<T>
    {

        /// <summary>
        /// Based on given baseUrl and stockCode, attempts to get a stock report CSV file and map the result to a given model
        /// </summary>
        /// <returns></returns>
        internal async Task<T> GetStockReport<T>(string stooqBaseUrl, string stockCode) where T : new()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(stooqBaseUrl + "?s=" + stockCode + "&e=csv");

            if (message.IsSuccessStatusCode)
            {
                var contentStream = await message.Content.ReadAsStreamAsync();

                using var reader = new StreamReader(contentStream);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                csv.Configuration.HasHeaderRecord = false;
                var stockReport = csv.GetRecords<T>().FirstOrDefault();
                return stockReport;
            }

            return default;
        }
    }
}