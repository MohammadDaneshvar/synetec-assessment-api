using Framework.Data;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence
{
    public class AppDbContext : DbContext, IDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public async Task BeginAsync(CancellationToken cancellationToken = default)
        {
            await Database.BeginTransactionAsync(cancellationToken);
        }

        public void Commit()
        {
            Database.CommitTransaction();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await Database.BeginTransactionAsync(cancellationToken);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            base.RemoveRange(entities);
        }

        void IDbContext.Remove<T>(T entity)
        {
            base.Remove(entity);
        }

        void IDbContext.Update<T>(T entity)
        {
            base.Update(entity);
        }

        public  IQueryable<T> Query<T>() where T : class
        {
            return base.Set<T>().AsQueryable();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> items, CancellationToken cancellationToken = default) where T : class
        {
            await base.AddRangeAsync(items, cancellationToken);
        }

        public new async Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            await base.AddAsync(entity, cancellationToken);
        }

        public  async Task<TEntity> FindAsync<TEntity, TKey>(TKey id, CancellationToken cancellationToken = default) where TEntity : class
        {
            var res = await base.FindAsync<TEntity>(new object[] { id }, cancellationToken);
            return res;
        }
    }
}
