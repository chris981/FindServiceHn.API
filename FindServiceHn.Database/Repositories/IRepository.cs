using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace FindServiceHn.Database.Repositories
{
    public interface IRepository<TEntity>
       where TEntity : class
    {
        IQueryable<TEntity> All();

        TEntity Create(TEntity entity);

        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);

        TEntity Delete(TEntity entity);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(params object[] keys);

        ValueTask<TEntity> FindAsync(params object[] keys);

        ValueTask<TEntity> FindAsync(CancellationToken token, params object[] keys);

        TEntity First(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> predicate);

        TEntity Update(TEntity entity);

        IOrderedQueryable<TEntity> OrderByDescending(Expression<Func<TEntity, object>> orderByExpression);

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
