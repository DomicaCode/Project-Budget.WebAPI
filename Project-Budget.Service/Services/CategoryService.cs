using Project_Budget.Common;
using Project_Budget.Common.Filters;
using Project_Budget.Model.Models;
using Project_Budget.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public ICategoryRepository CategoryRepository { get; }

        public async Task<bool> AddAsync(Category model)
        {
            return await CategoryRepository.InsertAsync(model);
        }


        public async Task<bool> DeleteAsync(Guid foodId)
        {
            return await CategoryRepository.DeleteAsync(foodId);
        }


        public async Task<bool> EditAsync(Category model)
        {
            return await CategoryRepository.EditAsync(model);
        }

        public async Task<IList<Category>> GetAllAsync(Guid userId)
        {
            var filter = new CategoryFilter
            {
                UserId = userId
            };

            return await CategoryRepository.GetAllAsync(filter);
        }

        public async Task<Category> GetAsync(CategoryFilter filter)
        {
            return await CategoryRepository.GetAsync(filter).ConfigureAwait(false);
        }
    }
}
