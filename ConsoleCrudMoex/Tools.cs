using MoexEntity;
using Serilog;

namespace ConsoleCrudMoex
{
    public class Tools<TEntity> where TEntity : CommonEntity
    {
        public static int? EncodingPageNumber { get; set; }

        public static async Task AddDb(string? dir, string? connectionString)
        {
            await Task.Run(() =>
            {
                Log.Information($"TEntity = {typeof(TEntity).Name}");

                if (!string.IsNullOrEmpty(dir) && !string.IsNullOrEmpty(connectionString))
                {
                    CsvOperations<TEntity>.EncodingPageNumber = Tools<TEntity>.EncodingPageNumber;

                    var crud = new CrudOperations<TEntity>(connectionString);
                    var csv = new CsvOperations<TEntity>();

                    foreach (var path in Directory.GetFiles(dir).Where(x => x.Contains("csv")))
                    {
                        var tick = DateTime.Now.Ticks;

                        Log.Information($"Читаем файл '{path}'");
                        var records = csv.ReadCsv($"{path}");

                        records?.ForEach(i => i.Pid = tick);
                        Log.Information($"Файл прочитан '{path}' строк значимых {records?.Count}");

                        if (records != null)
                        {
                            crud.AddRange(records);
                        }
                    }

                    if (!Directory.GetFiles(dir).Any(x => x.Contains("csv")))
                    {
                        Log.Information($"Папка '{dir}' пуста");
                    }
                }
            });
        }
    }
}
