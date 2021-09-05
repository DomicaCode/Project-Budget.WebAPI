using Project_Budget.Common;
using Project_Budget.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services
{
    public interface IEntryService
    {
        Task<bool> AddAsync(Entry model);
        Task<bool> DeleteAsync(Guid foodId);
        Task<bool> EditAsync(Entry model);
        Task<IList<Entry>> GetAllAsync(ExtendedFilter filter);
        Task<Entry> GetAsync(ExtendedFilter filter);
    }
}