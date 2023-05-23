using DocVision.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocVision.DataAccessLayer.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        protected readonly ApplicationDbContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true) =>
            asNoTracking ? await DbSet.AsNoTracking().ToListAsync() : await DbSet.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = true)
        {
            return asNoTracking ? await DbSet.Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync() :
                await DbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual void Create(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"{nameof(entity)} must be initialized");

            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"{nameof(entity)} must be initialized");

            DbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"{nameof(entity)} must be initialized");

            DbSet.Remove(entity);
        }

        void IDisposable.Dispose() => Context.Dispose();
    }
}
