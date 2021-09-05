using AutoMapper;
using Project_Budget.Common;
using Project_Budget.DAL.Context;
using Project_Budget.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category, GenericFilter>, ICategoryRepository
    {
        public CategoryRepository(BudgetContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

