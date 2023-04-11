using Microsoft.EntityFrameworkCore;

namespace ConsoleCrudMoex
{
    public class CrudOperations<TEntity> where TEntity : class
    {
        public CrudOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(TEntity item)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                context.Database.SetCommandTimeout(TimeSpan.FromSeconds(timeout));
                context.EnsureCreatingMissingTablesPosgtres();
                context.Items.Add(item);
                context.SaveChanges();
            }

        }

        public void AddRange(IEnumerable<TEntity> items)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                context.Database.SetCommandTimeout(TimeSpan.FromSeconds(timeout));
                context.EnsureCreatingMissingTablesPosgtres();
                context.Items.AddRange(items);
                context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                return context.Items.Where(predicate);
            }
        }

        public IEnumerable<TEntity> Get(Func<TEntity, int, bool> predicate)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                return context.Items.Where(predicate);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                return context.Items.ToList();
            }
        }

        public void Update(TEntity item)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                context.Items.Update(item);
                context.SaveChanges();
            }
        }
        public void UpdateRange(IEnumerable<TEntity> items)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                context.Items.UpdateRange(items);
                context.SaveChanges();
            }
        }

        public void Remove(TEntity item)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
        }
        public void RemoveRange(IEnumerable<TEntity> items)
        {
            using (var context = new ItemsPostgresContext<TEntity>(_connectionString))
            {
                context.Items.RemoveRange(items);
                context.SaveChanges();
            }
        }

        private readonly string _connectionString;
        private readonly int timeout = 10 * 60;
    }
}
