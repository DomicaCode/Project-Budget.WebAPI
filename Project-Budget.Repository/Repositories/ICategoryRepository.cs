using Project_Budget.Common;
using Project_Budget.Common.Filters;
using Project_Budget.Model.Models;
using Project_Budget.Model.Models.Membership;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, CategoryFilter>
    {
        Task<IList<Category>> GetAllAsync(CategoryFilter filter);
        Task<Category> GetAsync(CategoryFilter filter);
    }
}