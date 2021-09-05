using Project_Budget.Common;
using Project_Budget.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public interface ITypeRepository : IBaseRepository<Type, ExtendedFilter>
    {
        Task<IList<Type>> GetAllAsync(ExtendedFilter filter);
        new Task<Type> GetAsync(ExtendedFilter filter);
    }
}