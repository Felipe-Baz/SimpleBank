namespace simplebank.Repositories.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        Task AddAsync(T entity);

        void Add(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}