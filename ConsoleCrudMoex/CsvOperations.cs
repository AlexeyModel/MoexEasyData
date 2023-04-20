using CsvHelper;
using CsvHelper.Configuration;
using Serilog;
using System.Globalization;
using System.Text;

namespace ConsoleCrudMoex
{
    public class CsvOperations<TEntity> where TEntity : class
    {
        public static int? EncodingPageNumber { get; set; }

        public List<TEntity> ReadCsv(string path)
        {
            using var reader = new StreamReader(path, Encoding.GetEncoding(CsvOperations<TEntity>.EncodingPageNumber ?? Utf8CodePageNumber));

            var config = new CsvConfiguration(CultureInfo.CurrentCulture) {
                DetectDelimiter = true,
                BadDataFound = null,
                HeaderValidated = null
            };
            
            using var csv = new CsvReader(reader, config);

            var records = csv?.GetRecords<TEntity>();

            if (records == null) return new List<TEntity>();

            Log.Information($"Строки прочитаны. Количество {records.Count()}");

            return records.ToList();
        }

        private readonly int Utf8CodePageNumber = 65001;
    }
}
