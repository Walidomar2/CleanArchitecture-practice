using CleanArchitecture.Infrastructure.Presistence.Data;
using CleanArchitecute.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Presistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;
        private DbSet<TEntity> _entity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>(); 
        }

        public async Task<TEntity?> CreateAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity?> DeleteAsync(int id)
        {
            var deletedModel = await _entity.FindAsync(id);
            if (deletedModel != null)
            {
                _entity.Remove(deletedModel);
            } 
            return deletedModel;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public void UpdateAsync(TEntity entity)
        {
            _entity.Attach(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
