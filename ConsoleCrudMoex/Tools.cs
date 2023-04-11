using MoexEntity;

namespace ConsoleCrudMoex
{
    public class Tools<TEntity> where TEntity : CommonEntity
    {
        public static int? EncodingPageNumber { get; set; }

        public static async Task AddDb(string? dir, string? connectionString)
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(dir) && !string.IsNullOrEmpty(connectionString))
                {
                    CsvOperations<TEntity>.EncodingPageNumber = Tools<TEntity>.EncodingPageNumber;

                    var crud = new CrudOperations<TEntity>(connectionString);
                    var csv = new CsvOperations<TEntity>();

                    foreach (var path in Directory.GetFiles(dir).Where(x => x.Contains("csv")))
                    {
                        var tick = DateTime.Now.Ticks;

                        var records = csv.ReadCsv($"{path}");

                        records.ForEach(i => i.Pid = tick);

                        if (records != null)
                        {
                            crud.AddRange(records);
                        }
                    }
                }
            });
        }
    }
}
