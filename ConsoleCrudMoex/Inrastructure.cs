using Microsoft.EntityFrameworkCore;

namespace ConsoleCrudMoex
{
    public static class DbContextExtensions
    {
        public static void EnsureCreatingMissingTablesPosgtres<TDbContext>(this TDbContext dbContext) where TDbContext : DbContext
        {
            var tableName = dbContext.Model.GetEntityTypes().First().GetTableName();

            CheckTableExistsAndCreateIfMissing(dbContext, tableName ?? "");
        }

        private static void CheckTableExistsAndCreateIfMissing(DbContext dbContext, string entityName)
        {
            var defaultSchema = dbContext.Model.GetDefaultSchema();
            var tableName = string.IsNullOrWhiteSpace(defaultSchema) ? $"{entityName}" : $"{defaultSchema}.{entityName}";

            try
            {
                _ = dbContext.Database.ExecuteSqlRaw($"SELECT * FROM {tableName} limit 1");
            }
            catch (Exception)
            {
                var scriptStart = $"CREATE TABLE {tableName}";
                const string scriptEnd = "GO";
                var script = dbContext.Database.GenerateCreateScript();

                var tableScript = script.Split(scriptStart).Last().Split(scriptEnd);
                var first = $"{scriptStart} {tableScript.First()}";

                dbContext.Database.ExecuteSqlRaw(first);
            }
        }
    }
}