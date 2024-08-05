namespace CleanArchitecute.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity); 
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();   
        Task<TEntity> UpdateAsync(TEntity entity, int id);
        Task<TEntity> DeleteAsync(int id);
    }
}
