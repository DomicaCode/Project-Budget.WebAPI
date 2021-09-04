using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_Budget.Common;
using Project_Budget.DAL.Context;
using Project_Budget.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Repository
{
    public class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter> where TEntity : class, IBaseModel, new()
        where TFilter : class, IGenericFilter, new()
    {
        protected readonly DbSet<TEntity> DbSet;
        private readonly BudgetContext _context;


        public BaseRepository(BudgetContext context, IMapper mapper)
        {
            Mapper = mapper;
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        private IMapper Mapper { get; }


        public virtual async Task<bool> DeleteAsync(Guid entityId)
        {
            var filter = new TFilter
            {
                Id = entityId
            };
            var entity = await GetAsync(filter).ConfigureAwait(false);

            var result = DbSet.Remove(entity);

            if (result.State != EntityState.Deleted) return false;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public virtual async Task<bool> EditAsync(TEntity entity)
        {
            var filter = new TFilter
            {
                Id = entity.Id
            };

            var currentEntity = await GetAsync(filter).ConfigureAwait(false);

            var foodItemToEdit = Mapper.Map(entity, currentEntity);

            var result = DbSet.Update(foodItemToEdit);

            if (result.State != EntityState.Modified) return false;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetAsync(TFilter filter)
        {
            if (filter.Id != null)
            {
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == filter.Id).ConfigureAwait(false);
            }

            return null;
        }

        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateUpdated = DateTime.UtcNow;

            var result = await DbSet.AddAsync(entity).ConfigureAwait(false);

            if (result.State != EntityState.Added) return false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
