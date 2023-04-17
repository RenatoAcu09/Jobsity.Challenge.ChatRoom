using CsvHelper;
using Jobsity.Challenge.ChatRoom.Bot.Domain.DataContracts.Responses;
using Jobsity.Challenge.ChatRoom.Bot.Interfaces.Domain;
using System.Globalization;

namespace Jobsity.Challenge.ChatRoom.Bot.Domain.Converters
{
    public class ConvertStockPrice : ICommandConverter
    {
        public string Convert(string value)
        {
            using var reader = new StringReader(value);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<StockPriceResponse>().ToList();
            if (records is not null && records.Any())
            {
                return records.First();
            }

            return string.Empty;
        }
    }
}