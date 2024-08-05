namespace CleanArchitecute.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> CreateAsync(TEntity entity); 
        Task<TEntity?> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();   
        void UpdateAsync(TEntity entity);
        Task<TEntity?> DeleteAsync(int id);

        Task<int> SaveChangesAsync();
    }
}
