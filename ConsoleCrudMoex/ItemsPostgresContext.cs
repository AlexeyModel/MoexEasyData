using ClosedXML;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCrudMoex
{
    public class ItemsPostgresContext<TEntity> : DbContext where TEntity : class
    {
        public ItemsPostgresContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<TEntity> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeEntity = typeof(TEntity);
            var schemaName = typeEntity.GetAttributes<TableAttribute>().First().Schema;
            var tableName = typeEntity.Name.Replace("Entity", String.Empty).ToLower();

            modelBuilder.HasDefaultSchema(schemaName);
            modelBuilder.Entity<TEntity>().ToTable(tableName);

            base.OnModelCreating(modelBuilder);
        }

        private readonly string _connectionString;
    }
}
