using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FindServiceHn.Database.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
       where TEntity : class
       where TContext : FindServiceHnContext
    {
        public RepositoryBase(TContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets or sets the context used in this repository.
        /// </summary>
        public virtual TContext Context { get; protected set; }

        /// <summary>
        /// When is overriden in a derived type, returns all the elements in the entity set.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable"/> for all the elements in the entity set.
        /// </returns>
        public virtual IQueryable<TEntity> All()
        {
            return this.Context.Set<TEntity>();
        }

        /// <summary>
        /// Filters an entity set of values based on a predicate.
        /// </summary>
        /// <param name="predicate">
        /// An expression to test each element for a condition.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable"/> that contains elements from the input sequence that satisfy the condition specified by predicate.
        /// </returns>
        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return this.All().Where(predicate);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="predicate">
        /// A sequence of values to project.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IQueryable"/> whose elements are the result of invoking a projection function on each element of source.
        /// </returns>
        public virtual IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> predicate)
        {
            return this.All().Select(predicate);
        }

        /// <summary>
        /// Returns the first element of a sequence.
        /// </summary>
        /// <param name="predicate">
        /// An expression to return the first element of a condition.
        /// </param>
        /// <returns>
        /// The first element that satisfies the condition.
        /// </returns>
        public virtual TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Where(predicate).First();
        }

        public virtual TEntity Find(params object[] keys)
        {
            return ((DbSet<TEntity>)this.All()).Find(keys);
        }

        public virtual ValueTask<TEntity> FindAsync(params object[] keys)
        {
            return this.FindAsync(CancellationToken.None, keys);
        }

        public virtual ValueTask<TEntity> FindAsync(CancellationToken token, params object[] keys)
        {
            return ((DbSet<TEntity>)this.All()).FindAsync(keys, token);
        }

        /// <summary>
        /// Returns the first element of a sequence.
        /// </summary>
        /// <param name="predicate">
        /// An expression to return the first element of a condition.
        /// </param>
        /// <returns>
        /// The first element that satisfies the condition.
        /// </returns>
        public virtual Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Where(predicate).FirstAsync();
        }

        /// <summary>
        /// Marks the entity as added.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as added.
        /// </returns>
        public virtual TEntity Create(TEntity entity)
        {
            this.Context.Add(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
        {
            this.Context.AddRange(entities);
            return entities;
        }

        /// <summary>
        /// Marks the entity as modified.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as modified.
        /// </returns>
        public virtual TEntity Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public IOrderedQueryable<TEntity> OrderByDescending(Expression<Func<TEntity, object>> orderByExpression)
        {
            return this.Context.Set<TEntity>().OrderByDescending(orderByExpression);
        }

        public async Task<bool> EnsureDatabaseCreatedAsync()
        {
            return await this.Context.Database.EnsureCreatedAsync();
        }

        public void BulkDelete(IEnumerable<TEntity> entities)
        {
            this.Context.RemoveRange(entities);
        }

        /// <summary>
        /// Marks the entity as deleted.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as deleted.
        /// </returns>
        public virtual TEntity Delete(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await this.Context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying Database.
        /// </summary>
        /// <returns>The amount of changed records.</returns>
        public virtual int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync(bool suppressOperationMetadataUpdate)
        {
            return await this.Context.SaveChangesAsync(suppressOperationMetadataUpdate);
        }

        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.All().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return this.All().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<TEntity> ResetAsync(TEntity entity)
        {
            await this.Context.Entry(entity).ReloadAsync();
            return entity;
        }

        public void ResetTrackingState()
        {
            this.Context.ChangeTracker.Clear();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await this.Context.Database.BeginTransactionAsync();
        }

        private IEnumerable<IEnumerable<TEntity>> Batch(IEnumerable<TEntity> source, int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size", "Must be greater than zero.");
            }

            IEnumerator<TEntity> enumerator = null;
            try
            {
                enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return this.TakeIEnumerator(enumerator, size);
                }
            }
            finally
            {
                enumerator?.Dispose();
            }
        }

        private IEnumerable<TEntity> TakeIEnumerator(IEnumerator<TEntity> source, int size)
        {
            int i = 0;
            do
            {
                yield return source.Current;
            }
            while (++i < size && source.MoveNext());
        }
    }
}
