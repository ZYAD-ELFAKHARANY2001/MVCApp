using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IBaseRepository<TEntity, Tid>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetOneAsync(Tid id);
        IQueryable<TEntity> GoTo { get; }
        Task<int> SaveChangesAsync();
    }
}
