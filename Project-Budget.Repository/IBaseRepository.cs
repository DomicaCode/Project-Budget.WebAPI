using Project_Budget.Common;
using Project_Budget.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Repository
{
    public interface IBaseRepository<TEntity, TFilter>
        where TEntity : class, IBaseModel, new()
        where TFilter : class, IGenericFilter, new()
    {
        Task<bool> DeleteAsync(Guid entityId);
        Task<bool> EditAsync(TEntity entity);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TFilter filter);
        Task<bool> InsertAsync(TEntity entity);
    }
}