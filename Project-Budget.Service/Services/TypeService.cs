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
    public class TypeService : ITypeService
    {
        public TypeService(ITypeRepository typeRepository)
        {
            TypeRepository = typeRepository;
        }

        public ITypeRepository TypeRepository { get; }

        public async Task<bool> AddAsync(Model.Models.Type model)
        {
            return await TypeRepository.InsertAsync(model).ConfigureAwait(false);
        }


        public async Task<bool> DeleteAsync(Guid foodId)
        {
            return await TypeRepository.DeleteAsync(foodId).ConfigureAwait(false);
        }


        public async Task<bool> EditAsync(Model.Models.Type model)
        {
            return await TypeRepository.EditAsync(model).ConfigureAwait(false);
        }

        public async Task<IList<Model.Models.Type>> GetAllAsync()
        {

            return await TypeRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Model.Models.Type> GetAsync(GenericFilter filter)
        {
            return await TypeRepository
                .GetAsync(filter)
                .ConfigureAwait(false);
        }
    }
}
