using Project_Budget.Common;
using Project_Budget.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Budget.Service.Services
{
    public interface ITypeService
    {
        ITypeRepository TypeRepository { get; }

        Task<bool> AddAsync(Model.Models.Type model);
        Task<bool> DeleteAsync(Guid foodId);
        Task<bool> EditAsync(Model.Models.Type model);
        Task<IList<Model.Models.Type>> GetAllAsync();
        Task<Model.Models.Type> GetAsync(GenericFilter filter);
    }
}