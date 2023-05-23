namespace DocVision.Core.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable
            where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true);

        void Create(TEntity item); 

        void Update(TEntity item);

        void Delete(TEntity item);
    }
}
