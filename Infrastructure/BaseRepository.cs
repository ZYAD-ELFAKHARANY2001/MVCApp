using Application.Contract;
using Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseRepository<TEntity, Tid> : IBaseRepository<TEntity, Tid> where TEntity : class
    {
        private readonly ApplicationContext _systemContext;
        public readonly DbSet<TEntity> _DbsetEntity;
        public BaseRepository(ApplicationContext systemContext)
        {
            _systemContext = systemContext;
            _DbsetEntity = systemContext.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await _DbsetEntity.AddAsync(entity)).Entity;
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            return Task.FromResult(_DbsetEntity.Remove(entity).Entity);
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            //var r = _systemContext.Set<TEntity>();
            return Task.FromResult(_DbsetEntity.Select(s => s));
            
        }
       
        public IQueryable<TEntity> GoTo => _systemContext.Set<TEntity>();

        public async Task<TEntity> GetOneAsync(Tid id)
        {
            return await _DbsetEntity.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _systemContext.SaveChangesAsync();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            _systemContext.ChangeTracker.Clear();
            return Task.FromResult(_DbsetEntity.Update(entity).Entity);
        }
    }
}
