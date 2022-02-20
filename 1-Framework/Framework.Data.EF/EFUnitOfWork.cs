using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        public EFUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task BeginAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.BeginAsync(cancellationToken);
        }
        public  void Commit()
        {
            _dbContext.Commit();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
          await   _dbContext.RollbackAsync(cancellationToken);
        }
    }
}