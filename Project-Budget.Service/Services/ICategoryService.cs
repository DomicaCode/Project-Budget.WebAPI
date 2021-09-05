using Project_Budget.Common;
using Project_Budget.Common.Filters;
using Project_Budget.Model.Models;
using Project_Budget.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(Category model);
        Task<bool> DeleteAsync(Guid foodId);
        Task<bool> EditAsync(Category model);
        Task<IList<Category>> GetAllAsync(Guid userId);
        Task<Category> GetAsync(CategoryFilter filter);
    }
}