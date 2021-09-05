using Project_Budget.Common;
using Project_Budget.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Repository.Repositories
{
    public interface IEntryRepository : IBaseRepository<Entry, ExtendedFilter>
    {
        Task<IList<Entry>> GetAllAsync(ExtendedFilter filter);
        new Task<Entry> GetAsync(ExtendedFilter filter);
    }
}